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
using SchemaTypist.Core.Templating;
using SchemaTypist.Core.Utilities;

namespace SchemaTypist.Core
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection sc)
        {
            sc.AddSingleton<IFileSystemWrapper, FileSystemWrapper>();
            sc.AddSingleton<IPathNamespaceService, PathNamespaceService>();
            sc.AddSingleton<IPluginLoader, PluginLoader>();
            sc.AddSingleton<INamingService, NamingService>();
            sc.AddSingleton<ISqlVendorPluginLoader, SqlVendorPluginLoader>();
            sc.AddSingleton<ISqlVendorService, SqlVendorService>();
            sc.AddSingleton<ISchemataExtractorService, SchemataExtractorService>();
            sc.AddSingleton<ISchemataConverterService, SchemataConverterService>();
            sc.AddSingleton<ITemplateService, TemplateService>();
            sc.AddSingleton<ISchemaTypistService, SchemaTypistService>();
        }

        public static SchemaTypistSecrets ReadSecrets(string userSecretsId)
        {
            var configRoot = new ConfigurationBuilder()
                .AddUserSecrets(userSecretsId)
                .Build();
            var sts = configRoot.GetSection(nameof(SchemaTypistSecrets)).Get<SchemaTypistSecrets>();
            return sts;
        }
    }
}
