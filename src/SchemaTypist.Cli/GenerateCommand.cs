﻿using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchemaTypist.Core;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;

namespace SchemaTypist.Cli
{
    public class GenerateCommand : AsyncCommand<GenerateCommand.Settings>
    {
        private readonly ISchemaTypistService _schemaTypistService;

        public GenerateCommand(ISchemaTypistService schemaTypistService)
        {
            _schemaTypistService = schemaTypistService;
        }

        public override async Task<int> ExecuteAsync(CommandContext context, GenerateCommand.Settings settings)
        {
            Dictionary<string, TabularStructure> tableStructureMap = new();
            var connString = settings.ConnectionString;
            if (!string.IsNullOrWhiteSpace(settings.UserSecretsId))
                connString = Startup.ReadSecrets(settings.UserSecretsId).DatabaseConnectionString;
            var config = new CodeGenConfig
            {
                ConnectionString = connString,
                RootOutputDirectory = settings.RootOutputDir,
                GenerateEntitiesOnly = settings.EntitiesOnly,
                CreateImmutableEntities = settings.CreateImmutableEntities,
                CreateRecordEntities = settings.CreateRecordEntities
            };
            config.EntitiesOutputDirectory = settings.EntitiesOutputDir ?? config.EntitiesOutputDirectory;
            config.EntitiesCustomNamespace = settings.EntitiesCustomNamespace ?? config.EntitiesCustomNamespace;
            config.EntityNameSuffix = settings.EntityNameSuffix ?? config.EntityNameSuffix;
            config.GeneratePersistenceOnly = settings.PersistenceOnly;
            config.PersistenceOutputDirectory = settings.PersistenceOutputDir ?? config.PersistenceOutputDirectory;
            config.PersistenceCustomNamespace = settings.PersistenceCustomNamespace ?? config.PersistenceCustomNamespace;
            config.MapperNameSuffix = settings.MappingNameSuffix ?? config.MapperNameSuffix;
            config.RootNamespace = settings.RootNamespace ?? config.RootNamespace;
            config.Include = settings.Include ?? config.Include;
            config.Exclude = settings.Exclude ?? config.Exclude;
            config.StripPrefix = settings.StripPrefix ?? config.StripPrefix;
            config.StripSuffix = settings.StripSuffix ?? config.StripSuffix;
            config.TargetLanguageVersion = settings.TargetLanguageVersion ?? config.TargetLanguageVersion;
            
            if ((!string.IsNullOrWhiteSpace(settings.DatabaseVendor))
                && Enum.TryParse<SqlVendorType>(settings.DatabaseVendor, out var vendor)) 
                config.Vendor = vendor;
            
            await AnsiConsole.Status()
                .AutoRefresh(true)
                .Spinner(Spinner.Known.Aesthetic)
                .SpinnerStyle(Style.Parse("blue bold"))
                .StartAsync("Fetching schema details from database...", async ctx =>
                {
                    try
                    {
                        AnsiConsole.MarkupLine($" Inclusion rules: {config.Include}");
                        AnsiConsole.MarkupLine($" Exclusion rules: {config.Exclude}");
                        tableStructureMap = await _schemaTypistService.ExtractDbMetadata(config);
                        await Task.Delay(500);
                        AnsiConsole.MarkupLine($"Fetched schema details.  Generating code now...");
                        //await SchemaTypistService.Generate(dbMetadata, config);

                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.WriteException(ex);
                    }
                });

            await AnsiConsole.Progress()
                .AutoRefresh(true) // Turn off auto refresh
                .AutoClear(false)   // Do not remove the task list when done
                .HideCompleted(false)   // Hide tasks as they are completed
                .Columns(new ProgressColumn[]
                {
                    new TaskDescriptionColumn(),    // Task description
                    new ProgressBarColumn(),        // Progress bar
                    new PercentageColumn(),         // Percentage
                    new ElapsedTimeColumn(),
                    new SpinnerColumn(Spinner.Known.BouncingBar),            // Spinner
                })
                .StartAsync(async ctx =>
                {
                    var genTask = ctx.AddTask("[green]Generating source code...[/]", true, tableStructureMap.Count);
                    var tse = tableStructureMap.GetEnumerator();
                    while (!ctx.IsFinished && tse.MoveNext())
                    {
                        // Simulate some work
                        //AnsiConsole.MarkupLine($"Generating code for {tse.Current.Key}");

                        //genTask.Description = $"Generating code for {tse.Current.Key}";
                        await Task.Delay(500); 
                        _schemaTypistService.Generate(tse.Current.Value, config);
                        genTask.Increment(1);

                    }
                    
                    AnsiConsole.MarkupLine($"Generating Dapper Type Mapping");
                    _schemaTypistService.GenerateDapperMapping(tableStructureMap.Values.ToList(), config);
                });

            return 0;
        }

        public class Settings : CommandSettings
        {
            [Description("MicrosoftSqlServer or PostgreSql")]
            [CommandArgument(0, "[DATABASE_VENDOR]")]
            [DefaultValue("MicrosoftSqlServer")]
            public string DatabaseVendor { get; set; }

            [CommandArgument(1, "[ROOT_OUTPUT_DIR]")]
            [DefaultValue("")]
            public string RootOutputDir { get; set; }

            [Description("Static connection string to source database.")]
            [CommandArgument(2, "[CONNECTION_STRING]")]
            [DefaultValue("")]
            public string ConnectionString { get; set; }

            [Description("Use this option to generate domain model objects only.")]
            [CommandOption("-e|--entities-only")]
            [DefaultValue(false)]
            public bool EntitiesOnly { get; set; }

            [CommandOption("--entities-output-dir")]
            [DefaultValue("Domain")]
            public string EntitiesOutputDir { get; set; }

            [CommandOption("--entities-custom-namespace")]
            public string EntitiesCustomNamespace { get; set; }

            [CommandOption("--entity-name-suffix")]
            [DefaultValue("")]
            public string EntityNameSuffix{ get; set; }

            [Description("Use this option to generate data access layer only.  Remember, persistence code references entities.")]
            [CommandOption("-p|--persistence-only")]
            [DefaultValue(false)]
            public bool PersistenceOnly { get; set; }

            [CommandOption("--persistence-output-dir")]
            [DefaultValue("Persistence")]
            public string PersistenceOutputDir { get; set; }
            
            [CommandOption("--persistence-custom-namespace")]
            public string PersistenceCustomNamespace { get; set; }

            [CommandOption("--mapping-name-suffix")]
            [DefaultValue("Dao")]
            public string MappingNameSuffix { get; set; }
            
            [CommandOption("--root-namespace")]
            [DefaultValue("SchemaTypist.Generated")]
            public string RootNamespace { get; set; }

            [CommandOption("--include")]
            [DefaultValue("")]
            public string Include { get; set; }

            [CommandOption("--exclude")]
            [DefaultValue("")]
            public string Exclude { get; set; }

            [CommandOption("--create-immutable-entities")]
            [DefaultValue(false)]
            public bool CreateImmutableEntities { get; set; }

            [CommandOption("--create-record-entities")]
            [DefaultValue(false)]
            public bool CreateRecordEntities { get; set; }

            [CommandOption("--user-secrets-id")]
            [DefaultValue("")]
            public string UserSecretsId { get; set; }

            [CommandOption("--strip-prefix")]
            [DefaultValue("")]
            public string StripPrefix { get; set; }

            [CommandOption("--strip-suffix")]
            [DefaultValue("")]
            public string StripSuffix { get; set; }

            [Description("We support CSharp7_3, CSharp8 and CSharp10 (default).")]
            [CommandOption("--target-lang-version")]
            [DefaultValue("CSharp10")]
            public string TargetLanguageVersion { get; set; }

            /**
             * TODO:
             * 1.  Add support for multiple C# LangVersions (i.e. multiple target frameworks).
             * 2.  Add good readme and documentation.
             * 3.  Add CI integration.
             * 4.  Easier option to select all columns.
             * 5.  Add integration tests.
             * 6.  Enhance config:  Naming preference configurations, pluralisations and prefix handling.
             * 7.  Add indexes, foreign keys, etc. and generate DAO objects.
             * 8.  Support stored procedures and UDTs.
             * 9.  Computed columns support.
             * 10. Better multi-mapping support.
             * 11. Do validation correctly.
             * 12. Adding support for src generators and visual studio extensions.
             */
        }
    }

}
