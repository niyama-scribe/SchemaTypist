using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.Schemata;
using SchemaTypist.Core.Templating;
using SchemaTypist.Core.Utilities;

namespace SchemaTypist.Core
{
    internal class SchemaTypistService : ISchemaTypistService
    {
        private readonly IFileSystemWrapper _fileSystem;
        private readonly IPathNamespaceService _pathNamespaceService;
        private readonly ISchemataConverterService _schemataConverter;
        private readonly ISchemataExtractorService _schemataExtractor;
        private readonly ITemplateService _templateService;

        public SchemaTypistService(IFileSystemWrapper fileSystem,
            IPathNamespaceService pathNamespaceService,
            ISchemataExtractorService schemataExtractor,
            ISchemataConverterService schemataConverter,
            ITemplateService templateService)
        {
            _fileSystem = fileSystem;
            _pathNamespaceService = pathNamespaceService;
            _schemataExtractor = schemataExtractor;
            _schemataConverter = schemataConverter;
            _templateService = templateService;
        }

        #region Public Methods

        public async Task<Dictionary<string, TabularStructure>> ExtractDbMetadata(CodeGenConfig config)
        {
            var metadata = await _schemataExtractor.ExtractDbMetadata(config);
            //Convert to code generator model
            return _schemataConverter.Convert(metadata.TablesMetadata, config);
        }

        public void Generate(TabularStructure tab, CodeGenConfig config)
        {
            //Resolve templates to use
            _templateService.LoadTemplates(config);

            var pathNamespace = _pathNamespaceService.Resolve(config, tab);

            //Set up generation
            _pathNamespaceService.Prep(pathNamespace);

            //Generate model and mapping

            //Generate model and write to file
            var etm = new EntitiesTemplateModel
            {
                Config = config,
                TabularStructure = tab,
                PathNamespace = pathNamespace
            };

            var output = _templateService.GenerateEntity(etm);
            _fileSystem.WriteAllText(pathNamespace.EntitiesFilePath, output);

            //Generate mapping and write to file
            var ptm = new PersistenceTemplateModel
            {
                Config = config,
                TabularStructure = tab,
                PathNamespace = pathNamespace
            };
            output = _templateService.GeneratePersistence(ptm);
            _fileSystem.WriteAllText(pathNamespace.PersistenceFilePath, output);
        }

        public void GenerateDapperMapping(IEnumerable<TabularStructure> tableStructures, CodeGenConfig config)
        {
            var tabularStructures = tableStructures.ToList();
            var pathNamespace = _pathNamespaceService.Resolve(config, tabularStructures.First());
            var dapperInitialiserModel = new DapperInitialiserTemplateModel
            {
                Config = config,
                TemplateModels = tabularStructures.Select(s => new EntitiesTemplateModel
                {
                    Config = config,
                    PathNamespace = _pathNamespaceService.Resolve(config, s),
                    TabularStructure = s
                }).ToList(),
                PathNamespace = pathNamespace
            };
            var dapperInitialiserOutput = _templateService.GenerateDapperMapper(dapperInitialiserModel);

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