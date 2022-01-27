using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.Naming;
using SchemaTypist.Core.Schemata;
using SchemaTypist.Core.SqlVendors;
using SchemaTypist.Core.Utilities;

namespace SchemaTypist.Core
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection sc)
        {
            sc.AddOptions();
            sc.Configure<SchemaTypistSecrets>(Config.GetSection("SchemaTypistSecrets"));
            sc.AddSingleton<IFileSystemWrapper, FileSystemWrapper>();
            sc.AddSingleton<IPluginLoader, PluginLoader>();
            sc.AddSingleton<INamingService, LanguageService>();
            sc.AddSingleton<ISqlVendorPluginLoader, SqlVendorPluginLoader>();
            sc.AddSingleton<ISqlVendorService, SqlVendorService>();
            sc.AddSingleton<ISchemataExtractorService, SchemataExtractorService>();
            sc.AddSingleton<ISchemataConverterService, SchemataConverterService>();
            sc.AddSingleton<ISchemaTypistService, SchemaTypistService>();
        }

        public static IConfigurationRoot Configure()
        {
            Config = new ConfigurationBuilder()
                .AddUserSecrets("SchemaTypistSecrets")
                .Build();
            return Config;
        }

        public static IConfigurationRoot Config { get; private set; }
    }
}
