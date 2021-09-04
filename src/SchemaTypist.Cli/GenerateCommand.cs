using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
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
        public override async Task<int> ExecuteAsync(CommandContext context, GenerateCommand.Settings settings)
        {
            Dictionary<string, TabularStructure> tableStructureMap = new();
            var config = new CodeGenConfig()
            {
                ConnectionString = settings.ConnectionString,
                OutputDirectory = settings.OutputDir,
                GenerateEntitiesOnly = settings.EntitiesOnly,
                EntitiesNamespace = settings.EntitiesNamespace,
                EntityNameSuffix = settings.EntityNameSuffix,
                GeneratePersistenceOnly = settings.PersistenceOnly,
                PersistenceNamespace = settings.PersistenceNamespace,
                MappingNamespace = settings.MappingNamespace,
                MapperNameSuffix = settings.MappingNameSuffix
            };

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
                        tableStructureMap = await SchemaTypistService.ExtractDbMetadata(config);
                        await Task.Delay(500);
                        AnsiConsole.MarkupLine($"Fetched schema details.  Generating code ...");
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
                        await SchemaTypistService.Generate(tse.Current.Value, config);
                        genTask.Increment(1);

                    }
                    
                    AnsiConsole.MarkupLine($"Generating Dapper Type Mapping");
                    await SchemaTypistService.GenerateDapperMapping(tableStructureMap.Values.ToList(), config);
                });

            return 0;
        }

        public class Settings : CommandSettings
        {
            [CommandArgument(0, "<CONNECTION_STRING>")]
            public string ConnectionString { get; set; }

            [Description("MicrosoftSqlServer or PostgreSql")]
            [CommandArgument(2, "[DATABASE_VENDOR]")]
            [DefaultValue("MicrosoftSqlServer")]
            public string DatabaseVendor { get; set; }

            [CommandArgument(2, "[OUTPUT_DIR]")]
            [DefaultValue(".")]
            public string OutputDir { get; set; }

            [Description("Use this option to generate domain model objects only.")]
            [CommandOption("-e|--entities-only")]
            public bool EntitiesOnly { get; set; } = false;

            [CommandOption("--entities-namespace")]
            public string EntitiesNamespace { get; set; }

            [CommandOption("--entity-name-suffix")]
            public string EntityNameSuffix{ get; set; }

            [Description("Use this option to generate data access layer only.  Remember, persistence code references entities.")]
            [CommandOption("-p|--persistence-only")]
            public bool PersistenceOnly { get; set; } = false;

            [CommandOption("--persistence-namespace")]
            public string PersistenceNamespace { get; set; }

            [Description("This is the namespace for database metadata mapping classes within the persistence layer.")]
            [CommandOption("--mapping-namespace")]
            public string MappingNamespace { get; set; }

            [CommandOption("--mapping-name-suffix")]
            public string MappingNameSuffix { get; set; }
            
            [CommandOption("--root-namespace")]
            public string RootNamespace { get; set; }
            
            public override ValidationResult Validate()
            {
                //1.  Should be able to connect to the db.
                //2.  Should be able to access the directories.
                return SchemaTypistService.Validate(ConnectionString)
                    ? ValidationResult.Success()
                    : ValidationResult.Error(
                        "The database doesn't seem to be accessible.  Please ensure the database connection string is correct and the database is actually running.");
            }

            /**
             * TODO:
             * 1.  Add integration tests.
             * 2.  Do validation correctly.
             * 3.  Test with Postgres and add unit tests.  Upload to nuget.
             * 4.  Add good readme and documentation.
             * 5.  Make project public.
             * 6.  Add CI integration.
             * 7.  Add support for multiple C# LangVersions (effectively multiple .NET frameworks).
             * 8.  Keyword conflict resolution in generated code.
             * 9.  Enhance config:  Add regex expressions for include and excludes.
             * 10. Enhance config:  Naming preference configurations, pluralisations and prefix handling.
             * 11. Support multiple .net frameworks.
             * 12. Add indexes, foreign keys, etc. and generate DAO objects.
             * 13. Support stored procedures and UDTs.
             * 14. Adding support for src generators.
             * 15. Computed columns support.
             * 16. Better multi-mapping support.
             */
        }
    }

}
