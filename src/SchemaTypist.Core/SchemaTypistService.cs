using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.Naming;
using SchemaTypist.Core.Schemata;
using SchemaTypist.Core.SqlVendors;
using SchemaTypist.Core.Utilities;
using Scriban;
using Scriban.Runtime;

namespace SchemaTypist.Core
{
    public class SchemaTypistService
    {
        private static readonly IFileSystemWrapper FileSystem = new FileSystemWrapper();
        private static readonly Template ModelTemplate;
        private static readonly Template MappingTemplate;
        private static readonly Template DapperMappingTemplate;
        private static readonly IPluginLoader _pluginLoader = new PluginLoader();
        private static readonly INamingService _namingService = new LanguageService();
        private static readonly ISqlVendorService _sqlVendor = new SqlVendor(_pluginLoader);
        private static readonly ISchemataService SchemataExtractor = new SchemataService(_sqlVendor);
        private static readonly ISchemataConverterService SchemataConverter =
            new SchemataConverterService(_namingService, _sqlVendor);
        static SchemaTypistService()
        {
            var modelTemplateFile = "Entities.sbntxt";
            ModelTemplate = Template.Parse(EmbeddedResource.GetContent(modelTemplateFile), modelTemplateFile);
            var mappingTemplateFile = "Mapping.sbntxt";
            MappingTemplate = Template.Parse(EmbeddedResource.GetContent(mappingTemplateFile), mappingTemplateFile);
            var dapperTypeMappingTemplateFile = "DapperTypeMapping.sbntxt";
            DapperMappingTemplate = Template.Parse(EmbeddedResource.GetContent(dapperTypeMappingTemplateFile), dapperTypeMappingTemplateFile);
        }

        internal static string GenerateEntity(TabularStructure tableStructure)
        {
            //Generate entities
            return ModelTemplate.Render(tableStructure);
        }

        internal static string DetermineEntityFilePath(CodeGenConfig config, TabularStructure tab)
        {
            return FileSystem.Combine(config.EntitiesNamespace, tab.Schema, $"{tab.Name}{config.EntityNameSuffix}.{config.OutputFileNameSuffix}.cs");
        }

        internal static string GenerateMapper(TabularStructure tableStructure)
        {
            //Generate mappers
            return MappingTemplate.Render(tableStructure);
        }

        internal static string DetermineMapperFilePath(CodeGenConfig config, TabularStructure tab)
        {
            return FileSystem.Combine(config.PersistenceNamespace, tab.Schema,
                $"{tab.Name}{config.MapperNameSuffix}.{config.OutputFileNameSuffix}.cs");
        }

        internal static string DetermineDapperMapperFilePath(CodeGenConfig config)
        {
            return FileSystem.Combine(config.OutputDirectory, config.PersistenceNamespace, $"DapperTypeMapping.{config.OutputFileNameSuffix}.cs");
        }

        internal static void PrepDirectories(TabularStructure tableStructure, CodeGenConfig config)
        {
            FileSystem.EnsureDirectoryExists(config.OutputDirectory, config.EntitiesNamespace, tableStructure.Schema);
            
            FileSystem.EnsureDirectoryExists(config.OutputDirectory, config.PersistenceNamespace, tableStructure.Schema);
        }

        internal static string GenerateDapperMapper(IEnumerable<TabularStructure> tableStructures, CodeGenConfig config)
        {
            //Generate DapperMapper
            var dapperTypeMappingTemplateData = new DapperInitializerTemplateModel()
            {
                Config = config,
                TabularStructures = tableStructures.ToList()
            };

            return DapperMappingTemplate.Render(dapperTypeMappingTemplateData);

        }

        #region Public Methods

        public static async Task<Dictionary<string, TabularStructure>> ExtractDbMetadata(CodeGenConfig config)
        {
            var columnsDtos = await SchemataExtractor.ExtractDbMetadata(config);
            //Convert to code generator model
            return SchemataConverter.Convert(columnsDtos, config);
        }
        public static void Generate(TabularStructure tab, CodeGenConfig config)
        {
            //Set up generation
            PrepDirectories(tab, config);

            //Generate model and mapping
            
            //Generate model and write to file
            var output = GenerateEntity(tab);
            var modelFilePath = FileSystem.Combine(config.OutputDirectory, DetermineEntityFilePath(config, tab));
            FileSystem.WriteAllText(modelFilePath, output);

            //Generate mapping and write to file
            output = GenerateMapper(tab);
            var mappingFilePath = FileSystem.Combine(config.OutputDirectory, DetermineMapperFilePath(config, tab));
            FileSystem.WriteAllText(mappingFilePath, output);

        }
        public static void GenerateDapperMapping(IEnumerable<TabularStructure> tableStructures, CodeGenConfig config)
        {
            var mapperOutput = GenerateDapperMapper(tableStructures, config);

            //Write to file
            var dapperMapperFilePath = DetermineDapperMapperFilePath(config);
            FileSystem.WriteAllText(dapperMapperFilePath, mapperOutput);
        }
        public static bool Validate(string connectionString)
        {
            //TODO:  You should be able to connect to the db.
            //You should have access to the folders.
            return true;
        }

        #endregion

    }
}
