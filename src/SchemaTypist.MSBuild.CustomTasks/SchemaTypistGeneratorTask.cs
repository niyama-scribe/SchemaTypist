using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using Microsoft.Extensions.DependencyInjection;
using SchemaTypist.Core;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;

namespace SchemaTypist.MSBuild.CustomTasks
{
    public class SchemaTypistGeneratorTask : ContextAwareTask
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;
        public SchemaTypistGeneratorTask()
        {
            _services = new ServiceCollection();
            Startup.ConfigureServices(_services);
            _serviceProvider = _services.BuildServiceProvider();
        }

        [Required] public string DatabaseVendor { get; set; } = "MicrosoftSqlServer";
        [Required] public string RootOutputDir { get; set; } = "";
        public string ConnectionString { get; set; } = "";
        public bool EntitiesOnly { get; set; } = false;
        public string EntitiesOutputDir { get; set; } = "Domain";
        public string EntityNameSuffix { get; set; } = "";
        public bool PersistenceOnly { get; set; } = false;
        public string PersistenceOutputDir { get; set; } = "Persistence";
        public string PersistenceCustomNamespace { get; set; }
        public string MappingNameSuffix { get; set; } = "Dao";
        public string RootNamespace { get; set; } = "SchemaTypist.Generated";
        public string Include { get; set; } = "";
        public string Exclude { get; set; } = "";
        public bool CreateImmutableEntities { get; set; } = false;
        public bool CreateRecordEntities { get; set; } = false;
        public string UserSecretsId { get; set; } = "";
        public string StripPrefix { get; set; } = "";
        public string StripSuffix { get; set; } = "";

        /// <summary>
        /// We support CSharp7_3, CSharp8 and CSharp10 (default).
        /// </summary>
        public string TargetLanguageVersion { get; set; } = "CSharp10";

        public bool UseNullableRefTypes { get; set; } = false;

        protected override bool ExecuteInner()
        {
            //TODO: Validate.  For instance, we must receive either UserSecretsId or ConnectionString at the very least.

            var config = ConvertConfig();
            return ExecuteInnerAsync(config).GetAwaiter().GetResult();
        }

        private async Task<bool> ExecuteInnerAsync(CodeGenConfig config)
        {
            var schemaTypistService = _serviceProvider.GetService<ISchemaTypistService>();
            this.Log.LogMessage(MessageImportance.Normal, "Fetching schema details from database...");
            var tableStructureMap = await schemaTypistService.ExtractDbMetadata(config);
            await Task.Delay(500);
            this.Log.LogMessage(MessageImportance.Normal, "Fetched schema details.  Generating code now...");
            foreach (var kvp in tableStructureMap)
            {
                await Task.Delay(200);
                schemaTypistService.Generate(kvp.Value, config);
            }
            this.Log.LogMessage(MessageImportance.Normal, "Generating Dapper Type Mapping.");
            schemaTypistService.GenerateDapperMapping(tableStructureMap.Values.ToList(), config);
            return true;
        }

        private CodeGenConfig ConvertConfig()
        {
            return new CodeGenConfig();

        }
    }
}
