using System;
using System.Collections.Generic;
using Humanizer;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.SqlVendors;
using SchemaTypist.Core.Utilities;

namespace SchemaTypist.Core.Language
{
    internal static class LanguageService
    {
        public static string ConvertCatalogName(string sqlCatalogName, CodeGenConfig config) => 
            ConvertName(sqlCatalogName, config, s => s.Pascalize());

        public static string ConvertSchemaName(string sqlSchemaName, CodeGenConfig config, string enclosingType) =>
            ConvertName(sqlSchemaName, config, s => s.Pascalize());

        public static string ConvertTableName(string sqlTableName, CodeGenConfig config, string enclosingType) =>
            ConvertName(sqlTableName, config, s => s.Pascalize().Singularize(false));

        public static string ConvertColumnName(string sqlColumnName, CodeGenConfig config, HashSet<string> additionalNamesToAvoid) =>
            ConvertName(sqlColumnName, config, s => s.Pascalize().Singularize(false), additionalNamesToAvoid);

        private static string ConvertName(string name, CodeGenConfig config, Func<string, string> humanizerFunc, 
            HashSet<string> additionalNamesToAvoid = null)
        {
            //Ensure new name is not a Languages keyword or a SchemaTypist keyword.
            //If so, then disambiguate appropriately. 

            var proposedName = humanizerFunc(name);
            var programmingLanguage = Languages.GetProgrammingLanguage(config.TargetLanguage);
            var schemaTypistDsl = Languages.SchemaTypist;
            return Disambiguator.DisambiguateIdentifier(proposedName,
                s => programmingLanguage.HasConflict(s) || schemaTypistDsl.HasConflict(s), additionalNamesToAvoid);
        }
    }
}
