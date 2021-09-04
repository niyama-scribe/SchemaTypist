using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SchemaTypist.Cli
{
    class Program
    {
        static int Main(string[] args)
        {
            AnsiConsole.Render(
                new FigletText("SchemaTypist")
                    .LeftAligned()
                    .Color(Color.SteelBlue1));

            var app = new CommandApp();
            app.Configure((Action<IConfigurator>)(config =>
            {
                config.AddCommand<GenerateCommand>("generate");
            }));

            return app.Run(args);
        }
    }
}
