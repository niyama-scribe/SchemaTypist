using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.Schemata;
using Scriban;
using Scriban.Runtime;

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

        public static string GenerateEntity(TabularStructure tableStructure)
        {
            //Generate entities
            var modelTemplateFile = "Entities.sbntxt";
            var modelTemplate = Template.Parse(EmbeddedResource.GetContent(modelTemplateFile), modelTemplateFile);
            return modelTemplate.Render(tableStructure);
        }

        public static string DetermineEntityFilePath(CodeGenConfig config, TabularStructure tab)
        {
            return Path.Combine(config.EntitiesNamespace, $"{tab.Name}{config.EntityNameSuffix}.{config.OutputFileNameSuffix}.cs");
        }

        public static string GenerateMapper(TabularStructure tableStructure)
        {
            //Generate mappers
            var mappingTemplateFile = "Mapping.sbntxt";
            var mappingTemplate = Template.Parse(EmbeddedResource.GetContent(mappingTemplateFile), mappingTemplateFile);
            return mappingTemplate.Render(tableStructure);
        }

        public static string DetermineMapperFilePath(CodeGenConfig config, TabularStructure tab)
        {
            return Path.Combine(config.PersistenceNamespace, config.MappingNamespace, 
                $"{tab.Schema}.{tab.Name}{config.MapperNameSuffix}.{config.OutputFileNameSuffix}.cs");
        }

        public static string GenerateDapperMapper(IEnumerable<TabularStructure> tableStructures, CodeGenConfig config)
        {
            //Generate DapperMapper
            var dapperTypeMappingTemplateFile = "DapperTypeMapping.sbntxt";
            var dapperTypeMappingTemplate = Template.Parse(EmbeddedResource.GetContent(dapperTypeMappingTemplateFile), dapperTypeMappingTemplateFile);
            var dapperTypeMappingTemplateData = new DapperInitializerTemplateModel()
            {
                Config = config,
                TabularStructures = tableStructures.ToList()
            };

            return dapperTypeMappingTemplate.Render(dapperTypeMappingTemplateData);

        }

        public static string DetermineDapperMapperFilePath(CodeGenConfig config)
        {
            return Path.Combine(config.PersistenceNamespace, config.MappingNamespace, $"DapperTypeMapping.{config.OutputFileNameSuffix}.cs");
        }
        
        [Obsolete]
        public static void Generate(TabularStructure tableStructure, CodeGenConfig config)
        {
            //Set up generation
            var modelTargetDir = Path.Combine(config.OutputDirectory, config.EntitiesNamespace);
            if (!Directory.Exists(modelTargetDir)) Directory.CreateDirectory(modelTargetDir);

            var mappingTargetDir = Path.Combine(config.OutputDirectory, config.PersistenceNamespace, config.MappingNamespace);
            if (!Directory.Exists(mappingTargetDir)) Directory.CreateDirectory(mappingTargetDir);


            //Generate model and mapping
            var tab = tableStructure;
            
            //Generate model and write to file
            var output = GenerateEntity(tab);
            var modelFilePath = Path.Combine(config.OutputDirectory, DetermineEntityFilePath(config, tab));
            File.WriteAllText(modelFilePath, output);

            //Generate mapping and write to file
            output = GenerateMapper(tab);
            var mappingFilePath = Path.Combine(config.OutputDirectory, DetermineMapperFilePath(config, tab));
            File.WriteAllText(mappingFilePath, output);

        }

        [Obsolete]
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

            var mapperOutput = await dapperTypeMappingTemplate.RenderAsync(dapperTypeMappingTemplateData);

            //Write to file
            var dapperMapperFilePath = DetermineDapperMapperFilePath(config);
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
