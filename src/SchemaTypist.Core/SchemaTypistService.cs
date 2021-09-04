using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.Schemata;
using Scriban;

namespace SchemaTypist.Core
{
    public class SchemaTypistService
    {
        public static async Task<Dictionary<string, TabularStructure>> ExtractDbMetadata(CodeGenConfig config)
        {
            var columnsDtos =  await SchemataService.ExtractDbMetadata(config);
            //Convert to code generator model
            return ModelConverterService.Convert(columnsDtos, config);
        }

        public static async Task Generate(TabularStructure tableStructure, CodeGenConfig config)
        {
            //Set up model generation
            var modelTemplateFile = "Entities.sbntxt";
            var modelTemplate = Template.Parse(EmbeddedResource.GetContent(modelTemplateFile), modelTemplateFile);
            var modelTargetDir = Path.Combine(config.OutputDirectory, config.EntitiesNamespace);
            if (!Directory.Exists(modelTargetDir)) Directory.CreateDirectory(modelTargetDir);

            //Set up mapping generation
            var mappingTemplateFile = "Mapping.sbntxt";
            var mappingTemplate = Template.Parse(EmbeddedResource.GetContent(mappingTemplateFile), mappingTemplateFile);
            var mappingTargetDir = Path.Combine(config.OutputDirectory, config.PersistenceNamespace, config.MappingNamespace);
            if (!Directory.Exists(mappingTargetDir)) Directory.CreateDirectory(mappingTargetDir);


            //Generate model and mapping
            var tab = tableStructure;
            
            //Generate model and write to file
            var output = modelTemplate.Render(tab);
            var modelFilePath = Path.Combine(modelTargetDir, $"{tab.Name}{config.EntityNameSuffix}.{config.OutputFileNameSuffix}.cs");
            File.WriteAllText(modelFilePath, output);

            //Generate mapping and write to file
            output = mappingTemplate.Render(tab);
            var mappingFilePath = Path.Combine(mappingTargetDir, $"{tab.Schema}.{tab.Name}{config.MapperNameSuffix}.{config.OutputFileNameSuffix}.cs");
            File.WriteAllText(mappingFilePath, output);

        }

        public static async Task GenerateDapperMapping(IEnumerable<TabularStructure> tableStructures, CodeGenConfig config)
        {
            //Generate DapperMapper
            var dapperTypeMappingTemplateFile = "DapperTypeMapping.sbntxt";
            var dapperTypeMappingTemplate = Template.Parse(EmbeddedResource.GetContent(dapperTypeMappingTemplateFile), dapperTypeMappingTemplateFile);
            var dapperTypeMappingTemplateData = new DapperInitializerTemplateModel()
            {
                Config = config,
                TabularStructures = tableStructures.ToList()
            };

            var mapperOutput = dapperTypeMappingTemplate.Render(dapperTypeMappingTemplateData);

            //Write to file
            var dapperMapperFilePath = Path.Combine(config.OutputDirectory, config.PersistenceNamespace, config.MappingNamespace, $"DapperTypeMapping.{config.OutputFileNameSuffix}.cs");
            File.WriteAllText(dapperMapperFilePath, mapperOutput);
        }

        public static bool Validate(string connectionString)
        {
            //TODO:  You should be able to connect to the db.
            //You should have access to the folders.
            return true;
        }

    }

    class TemplateConstants
    {
        public const string FileNameExtension = ".sbntxt";
        public const string Model = "Model";
        public const string Mapping = "Mapping";
        public const string DapperTypeMapping = "DapperTypeMapping";
    }
}
