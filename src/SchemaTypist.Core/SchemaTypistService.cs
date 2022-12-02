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
        private Template EntitiesTemplate;
        private Template PersistenceTemplate;
        private Template DapperInitialiserTemplate;
        private readonly IFileSystemWrapper _fileSystem;
        private readonly IPathNamespaceService _pathNamespaceService;
        private readonly ISchemataExtractorService _schemataExtractor;
        private readonly ISchemataConverterService _schemataConverter;

        public SchemaTypistService(IFileSystemWrapper fileSystem, 
            IPathNamespaceService pathNamespaceService,
            ISchemataExtractorService schemataExtractor, 
            ISchemataConverterService schemataConverter)
        {
            _fileSystem = fileSystem;
            _pathNamespaceService = pathNamespaceService;
            _schemataExtractor = schemataExtractor;
            _schemataConverter = schemataConverter;
        }

        internal Template GetTemplate(string templateFileName)
        {
            return Template.Parse(EmbeddedResource.GetContent(templateFileName), templateFileName);
        }

        internal void LoadTemplates(CodeGenConfig config)
        {
            var (entitiesTemplateName, persistenceTemplateName, dapperInitialiserTemplateName) =
                TemplateConstants.GetTemplateFileNames(config);

            EntitiesTemplate = GetTemplate(entitiesTemplateName);
            PersistenceTemplate = GetTemplate(persistenceTemplateName);
            DapperInitialiserTemplate = GetTemplate(dapperInitialiserTemplateName);

            if (EntitiesTemplate.HasErrors)
            {
                foreach (var entitiesTemplateMessage in EntitiesTemplate.Messages)
                {
                    Console.WriteLine(entitiesTemplateMessage);
                }
            }
        }

        internal string GenerateEntity(TableStructureTemplateModel tableStructureModel)
        {
            //Generate entities
            return EntitiesTemplate.Render(tableStructureModel);
        }

        internal string GeneratePersistence(PersistenceTemplateModel persistenceModel)
        {
            //Generate mappers
            return PersistenceTemplate.Render(persistenceModel);
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
            //Resolve templates to use
            LoadTemplates(config);
            
            var pathNamespace = _pathNamespaceService.Resolve(config, tab);
            
            //Set up generation
            _pathNamespaceService.Prep(pathNamespace);

            //Generate model and mapping
            
            //Generate model and write to file
            var etm = new EntitiesTemplateModel()
            {
                Config = config,
                TabularStructure = tab,
                PathNamespace = pathNamespace
            };

            var output = GenerateEntity(etm);
            _fileSystem.WriteAllText(pathNamespace.EntitiesFilePath, output);

            //Generate mapping and write to file
            var ptm = new PersistenceTemplateModel()
            {
                Config = config,
                TabularStructure = tab,
                PathNamespace = pathNamespace
            };
            output = GeneratePersistence(ptm);
            _fileSystem.WriteAllText(pathNamespace.PersistenceFilePath, output);

        }
        public void GenerateDapperMapping(IEnumerable<TabularStructure> tableStructures, CodeGenConfig config)
        {
            var tabularStructures = tableStructures.ToList();
            var pathNamespace = _pathNamespaceService.Resolve(config, tabularStructures.First());
            var dapperInitialiserModel = new DapperInitialiserTemplateModel()
            {
                Config = config,
                TemplateModels = tabularStructures.Select(s => new EntitiesTemplateModel()
                {
                    Config = config,
                    PathNamespace = _pathNamespaceService.Resolve(config, s),
                    TabularStructure = s
                }).ToList(),
                PathNamespace = pathNamespace
            };
            var dapperInitialiserOutput = GenerateDapperMapper(dapperInitialiserModel);

            //Write to file
            _fileSystem.WriteAllText(pathNamespace.DapperInitialiserFilePath, dapperInitialiserOutput);
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
