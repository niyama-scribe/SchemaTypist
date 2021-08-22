using SchemaTypist.Config;
using SchemaTypist.Model;
using SchemaTypist.Schemata;
using SchemaTypist.Schemata.Dto;
using Humanizer;
using Scriban;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist
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
            var modelTemplateFile = "Model.sbntxt";
            var modelTemplate = Template.Parse(EmbeddedResource.GetContent(modelTemplateFile), modelTemplateFile);
            var modelTargetDir = Path.Combine(config.TargetRootDirectory, config.ModelNamespace);
            if (!Directory.Exists(modelTargetDir)) Directory.CreateDirectory(modelTargetDir);

            //Set up mapping generation
            var mappingTemplateFile = "Mapping.sbntxt";
            var mappingTemplate = Template.Parse(EmbeddedResource.GetContent(mappingTemplateFile), mappingTemplateFile);
            var mappingTargetDir = Path.Combine(config.TargetRootDirectory, config.MappingNamespace);
            if (!Directory.Exists(mappingTargetDir)) Directory.CreateDirectory(mappingTargetDir);


            //Generate model and mapping
            var tab = tableStructure;
            
            //Generate model and write to file
            var output = modelTemplate.Render(tab);
            var modelFilePath = Path.Combine(modelTargetDir, $"{tab.Name}{config.ModelNameSuffix}.{config.TargetFileNameSuffix}.cs");
            File.WriteAllText(modelFilePath, output);

            //Generate mapping and write to file
            output = mappingTemplate.Render(tab);
            var mappingFilePath = Path.Combine(mappingTargetDir, $"{tab.Schema}.{tab.Name}.{config.TargetFileNameSuffix}.cs");
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
            var dapperMapperFilePath = Path.Combine(config.TargetRootDirectory, config.MappingNamespace, $"DapperTypeMapping.{config.TargetFileNameSuffix}.cs");
            File.WriteAllText(dapperMapperFilePath, mapperOutput);
        }

        public static bool Validate(string connectionString)
        {
            //TODO:  Validate connection string
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
