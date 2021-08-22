using SchemaTypist.Config;
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
using SchemaTypist.Model;
using SchemaTypist.Schemata.Dto;

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
                TargetRootDirectory = settings.OutputDir
            };


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

            [CommandArgument(1, "[OUTPUT_DIR]")]
            [DefaultValue(".")]
            public string OutputDir { get; set; }

            [CommandOption("-m|--model-only")]
            public bool ModelOnly { get; set; } = false;

            public override ValidationResult Validate()
            {
                return SchemaTypistService.Validate(ConnectionString)
                    ? ValidationResult.Success()
                    : ValidationResult.Error(
                        "The database doesn't seem to be accessible.  Please ensure the database connection string is correct and the database is actually running.");
            }
        }
    }

}
