using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SchemaTypist.Core;

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

            Startup.Configure();
            var registrations = new ServiceCollection();
            Startup.ConfigureServices(registrations);
            var registrar = new TypeRegistrar(registrations);
            var app = new CommandApp(registrar);
            app.Configure((Action<IConfigurator>)(config =>
            {
                config.AddCommand<GenerateCommand>("generate");
            }));

            return app.Run(args);
        }
    }
}
