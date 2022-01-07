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
    public class SchemaTypistService : ISchemaTypistService
    {
        private static readonly Template ModelTemplate;
        private static readonly Template MappingTemplate;
        private static readonly Template DapperMappingTemplate;
        private readonly IFileSystemWrapper _fileSystem;
        private readonly IPluginLoader _pluginLoader;
        private readonly INamingService _namingService;
        private readonly ISqlVendorService _sqlVendor;
        private readonly ISchemataService _schemataExtractor;
        private readonly ISchemataConverterService _schemataConverter;

        public SchemaTypistService()
        {
            _fileSystem = new FileSystemWrapper();
            _pluginLoader = new PluginLoader();
            _namingService = new LanguageService();
            _sqlVendor = new SqlVendor(_pluginLoader);
            _schemataExtractor = new SchemataService(_sqlVendor);
            _schemataConverter = new SchemataConverterService(_namingService, _sqlVendor);
        }


        static SchemaTypistService()
        {
            var modelTemplateFile = "Entities.sbntxt";
            ModelTemplate = Template.Parse(EmbeddedResource.GetContent(modelTemplateFile), modelTemplateFile);
            var mappingTemplateFile = "Mapping.sbntxt";
            MappingTemplate = Template.Parse(EmbeddedResource.GetContent(mappingTemplateFile), mappingTemplateFile);
            var dapperTypeMappingTemplateFile = "DapperTypeMapping.sbntxt";
            DapperMappingTemplate = Template.Parse(EmbeddedResource.GetContent(dapperTypeMappingTemplateFile), dapperTypeMappingTemplateFile);
        }

        internal string GenerateEntity(TabularStructure tableStructure)
        {
            //Generate entities
            return ModelTemplate.Render(tableStructure);
        }

        internal string DetermineEntityFilePath(CodeGenConfig config, TabularStructure tab)
        {
            return _fileSystem.Combine(config.EntitiesNamespace, tab.Schema, $"{tab.Name}{config.EntityNameSuffix}.{config.OutputFileNameSuffix}.cs");
        }

        internal string GenerateMapper(TabularStructure tableStructure)
        {
            //Generate mappers
            return MappingTemplate.Render(tableStructure);
        }

        internal string DetermineMapperFilePath(CodeGenConfig config, TabularStructure tab)
        {
            return _fileSystem.Combine(config.PersistenceNamespace, tab.Schema,
                $"{tab.Name}{config.MapperNameSuffix}.{config.OutputFileNameSuffix}.cs");
        }

        internal string DetermineDapperMapperFilePath(CodeGenConfig config)
        {
            return _fileSystem.Combine(config.OutputDirectory, config.PersistenceNamespace, $"DapperTypeMapping.{config.OutputFileNameSuffix}.cs");
        }

        internal void PrepDirectories(TabularStructure tableStructure, CodeGenConfig config)
        {
            _fileSystem.EnsureDirectoryExists(config.OutputDirectory, config.EntitiesNamespace, tableStructure.Schema);
            
            _fileSystem.EnsureDirectoryExists(config.OutputDirectory, config.PersistenceNamespace, tableStructure.Schema);
        }

        internal string GenerateDapperMapper(IEnumerable<TabularStructure> tableStructures, CodeGenConfig config)
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

        public async Task<Dictionary<string, TabularStructure>> ExtractDbMetadata(CodeGenConfig config)
        {
            var columnsDtos = await _schemataExtractor.ExtractDbMetadata(config);
            //Convert to code generator model
            return _schemataConverter.Convert(columnsDtos, config);
        }
        public void Generate(TabularStructure tab, CodeGenConfig config)
        {
            //Set up generation
            PrepDirectories(tab, config);

            //Generate model and mapping
            
            //Generate model and write to file
            var output = GenerateEntity(tab);
            var modelFilePath = _fileSystem.Combine(config.OutputDirectory, DetermineEntityFilePath(config, tab));
            _fileSystem.WriteAllText(modelFilePath, output);

            //Generate mapping and write to file
            output = GenerateMapper(tab);
            var mappingFilePath = _fileSystem.Combine(config.OutputDirectory, DetermineMapperFilePath(config, tab));
            _fileSystem.WriteAllText(mappingFilePath, output);

        }
        public void GenerateDapperMapping(IEnumerable<TabularStructure> tableStructures, CodeGenConfig config)
        {
            var mapperOutput = GenerateDapperMapper(tableStructures, config);

            //Write to file
            var dapperMapperFilePath = DetermineDapperMapperFilePath(config);
            _fileSystem.WriteAllText(dapperMapperFilePath, mapperOutput);
        }
        public bool Validate(string connectionString)
        {
            //TODO:  You should be able to connect to the db.
            //You should have access to the folders.
            return true;
        }

        #endregion

    }

    public interface ISchemaTypistService
    {
        Task<Dictionary<string, TabularStructure>> ExtractDbMetadata(CodeGenConfig config);
        void Generate(TabularStructure tab, CodeGenConfig config);
        void GenerateDapperMapping(IEnumerable<TabularStructure> tableStructures, CodeGenConfig config);
        bool Validate(string connectionString);
    }
}
