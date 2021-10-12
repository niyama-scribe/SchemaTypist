using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.CodeAnalysis;
using SchemaTypist.Core;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Utilities;

namespace SchemaTypist.SrcGen
{
    /// <summary>
    /// Entry point for SchemaTypist.
    /// </summary>
    [Generator]
    public class SchemaTypistSourceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            //Do nothing...
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (ShouldGenerate(context))
            {
                var codeGenConfig = ExtractCodeGenConfigFromBuildProps(context);
                var databaseBlueprint = SchemaTypistService.ExtractDbMetadata(codeGenConfig).GetAwaiter().GetResult();

                CleanOutputDirectory(codeGenConfig);
                
                var tse = databaseBlueprint.GetEnumerator();
                while (tse.MoveNext())
                {
                    var tab = tse.Current.Value;
                    context.AddSource(SchemaTypistService.DetermineEntityFilePath(codeGenConfig, tab),
                        SchemaTypistService.GenerateEntity(tab));

                    context.AddSource(SchemaTypistService.DetermineMapperFilePath(codeGenConfig, tab), 
                        SchemaTypistService.GenerateMapper(tab));
                }

                context.AddSource(SchemaTypistService.DetermineDapperMapperFilePath(codeGenConfig),
                    SchemaTypistService.GenerateDapperMapper(databaseBlueprint.Values.ToList(), codeGenConfig));
            }
        }

        private static void CleanOutputDirectory(CodeGenConfig codeGenConfig)
        {
            if (Directory.Exists(codeGenConfig.OutputDirectory))
                Directory.Delete(codeGenConfig.OutputDirectory, true);
            Directory.CreateDirectory(codeGenConfig.OutputDirectory);

        }

        private static bool ShouldGenerate(GeneratorExecutionContext context)
        {
            bool shouldGenerate = false;
            if (TryGetBuildProp(context, "Generate", out var stGenerateValue))
                shouldGenerate = stGenerateValue.Equals("true", StringComparison.OrdinalIgnoreCase);
            return shouldGenerate;
        }


        private static CodeGenConfig ExtractCodeGenConfigFromBuildProps(GeneratorExecutionContext context)
        {
            var config = new CodeGenConfig();
            MergeProp(context, config, c => c.ConnectionString);
            MergeProp(context, config, c => c.Vendor);
            MergeProp(context, config, c => c.TargetFramework);
            MergeProp(context, config, c => c.TargetLanguage);
            MergeProp(context, config, c => c.TargetLanguageVersion);
            MergeProp(context, config, c => c.OutputFileNameSuffix);
            MergeProp(context, config, c => c.GenerateEntitiesOnly);
            MergeProp(context, config, c => c.EntitiesNamespace);
            MergeProp(context, config, c => c.EntityNameSuffix);
            MergeProp(context, config, c => c.GeneratePersistenceOnly);
            MergeProp(context, config, c => c.PersistenceNamespace);
            MergeProp(context, config, c => c.MappingNamespace);
            MergeProp(context, config, c => c.MapperNameSuffix);
            MergeProp(context, config, c => c.RootNamespace);
            MergeProp(context, config, c => c.NamingConflictResolutionSuffix);
            MergeProp(context, config, c => c.Include);
            MergeProp(context, config, c => c.Exclude);
            return config;
        }
        

        private static void MergeProp(GeneratorExecutionContext context, CodeGenConfig config, Expression<Func<CodeGenConfig, object>> expression)
        {
            var propInfo = (PropertyInfo) ReflectionHelper.GetMemberInfo(expression);
            if (TryGetBuildProp(context, propInfo.Name, out var someVal))
                ReflectionHelper.SetPropertyVal(config, propInfo, someVal);
        }

        

        private static bool TryGetBuildProp(GeneratorExecutionContext context, string name, out string val)
        {
            return context.AnalyzerConfigOptions.GlobalOptions.TryGetValue($"build_property.{name}", out val);
        }
    }
}
