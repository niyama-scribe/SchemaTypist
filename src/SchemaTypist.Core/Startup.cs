using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
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
            sc.AddSingleton<IFileSystemWrapper, FileSystemWrapper>();
            sc.AddSingleton<IPluginLoader, PluginLoader>();
            sc.AddSingleton<INamingService, LanguageService>();
            sc.AddSingleton<ISqlVendorService, SqlVendor>();
            sc.AddSingleton<ISchemataService, SchemataService>();
            sc.AddSingleton<ISchemataConverterService, SchemataConverterService>();
            sc.AddSingleton<ISchemaTypistService, SchemaTypistService>();
        }
    }
}
