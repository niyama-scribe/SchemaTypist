using Humanizer;
using SchemaTypist.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.Language
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
            //Ensure new name is not a CSharp keyword or a database dialect keyword or a SchemaTypist keyword.
            //If so, then add an _ at the end of it. 

            var proposedName = humanizerFunc(name);
            var sqlDialect = SqlVendors.Vendors.GetSqlDialect(config.Vendor);
            while (CSharp.Keywords.Contains(proposedName)
                || sqlDialect.Keywords.Contains(proposedName)
                || sqlDialect.DataTypes.Contains(proposedName))
                proposedName += "_";
            return proposedName;
        }
    }
}
