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
using static SchemaTypist.Core.TemplateConstants;

namespace SchemaTypist.Core
{
    public class SchemaTypistService : ISchemaTypistService
    {
        private static readonly Template EntitiesTemplate;
        private static readonly Template PersistenceTemplate;
        private static readonly Template DapperInitialiserTemplate;
        private readonly IFileSystemWrapper _fileSystem;
        private readonly IPluginLoader _pluginLoader;
        private readonly INamingService _namingService;
        private readonly ISqlVendorService _sqlVendor;
        private readonly ISchemataExtractorService _schemataExtractor;
        private readonly ISchemataConverterService _schemataConverter;

        public SchemaTypistService(IFileSystemWrapper fileSystem, IPluginLoader pluginLoader, 
            INamingService namingService, ISqlVendorService sqlVendor, ISchemataExtractorService schemataExtractor, 
            ISchemataConverterService schemataConverter)
        {
            _fileSystem = fileSystem;
            _pluginLoader = pluginLoader;
            _namingService = namingService;
            _sqlVendor = sqlVendor;
            _schemataExtractor = schemataExtractor;
            _schemataConverter = schemataConverter;
        }

        static SchemaTypistService()
        {
            EntitiesTemplate = Template.Parse(EmbeddedResource.GetContent(EntitiesTemplateFile), EntitiesTemplateFile);
            PersistenceTemplate = Template.Parse(EmbeddedResource.GetContent(PersistenceTemplateFile), PersistenceTemplateFile);
            DapperInitialiserTemplate = Template.Parse(EmbeddedResource.GetContent(DapperInitialiserTemplateFile), DapperInitialiserTemplateFile);
        }

        internal string GenerateEntity(EntitiesTemplateModel entitiesModel)
        {
            //Generate entities
            return EntitiesTemplate.Render(entitiesModel);
        }

        internal string DetermineEntityFilePath(CodeGenConfig config, TabularStructure tab)
        {
            return _fileSystem.Combine(config.EntitiesNamespace, tab.Schema, $"{tab.Name}{config.EntityNameSuffix}.{config.OutputFileNameSuffix}.cs");
        }

        internal string GeneratePersistence(PersistenceTemplateModel persistenceModel)
        {
            //Generate mappers
            return PersistenceTemplate.Render(persistenceModel);
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

        internal string GenerateDapperMapper(DapperInitialiserTemplateModel dapperInitialiserModel)
        {
            //Generate DapperMapper
            return DapperInitialiserTemplate.Render(dapperInitialiserModel);

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
            var etm = new EntitiesTemplateModel()
            {
                Config = config,
                TabularStructure = tab
            };
            var output = GenerateEntity(etm);
            var modelFilePath = _fileSystem.Combine(config.OutputDirectory, DetermineEntityFilePath(config, tab));
            _fileSystem.WriteAllText(modelFilePath, output);

            //Generate mapping and write to file
            var ptm = new PersistenceTemplateModel()
            {
                Config = config,
                TabularStructure = tab
            };
            output = GeneratePersistence(ptm);
            var mappingFilePath = _fileSystem.Combine(config.OutputDirectory, DetermineMapperFilePath(config, tab));
            _fileSystem.WriteAllText(mappingFilePath, output);

        }
        public void GenerateDapperMapping(IEnumerable<TabularStructure> tableStructures, CodeGenConfig config)
        {
            var dapperInitialiserModel = new DapperInitialiserTemplateModel()
            {
                Config = config,
                TabularStructures = tableStructures.ToList()
            };
            var mapperOutput = GenerateDapperMapper(dapperInitialiserModel);

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
