using System;
using Humanizer;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.SqlVendors;

namespace SchemaTypist.Core.Language
{
    static class LanguageService
    {
        public static string ConvertCatalogName(string sqlCatalogName, CodeGenConfig config) => 
            ConvertName(sqlCatalogName, config, s => s.Pascalize());

        public static string ConvertSchemaName(string sqlCatalogName, CodeGenConfig config) =>
            ConvertName(sqlCatalogName, config, s => s.Pascalize());

        public static string ConvertTableName(string sqlCatalogName, CodeGenConfig config) =>
            ConvertName(sqlCatalogName, config, s => s.Pascalize().Singularize(false));

        public static string ConvertColumnName(string sqlCatalogName, CodeGenConfig config) =>
            ConvertName(sqlCatalogName, config, s => s.Pascalize().Singularize(false));

        private static string ConvertName(string name, CodeGenConfig config, Func<string, string> humanizerFunc)
        {
            //Ensure new name is not a Languages keyword or a database dialect keyword or a SchemaTypist keyword.
            //If so, then add an 0 at the end of it. 

            var proposedName = humanizerFunc(name);
            var sqlDialect = SqlVendor.GetSqlDialect(config.Vendor);
            var programmingLanguage = Languages.GetProgrammingLanguage(config.TargetLanguage);
            while (programmingLanguage.HasConflict(proposedName) || 
                   sqlDialect.HasConflict(proposedName))
                proposedName += "0";
            return proposedName;
        }
    }
}
