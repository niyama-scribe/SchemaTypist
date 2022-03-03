using System;
using System.Collections.Generic;
using System.Linq;
using Humanizer;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Language;
using SchemaTypist.Core.Utilities;

namespace SchemaTypist.Core.Naming
{
    internal class NamingService : INamingService
    {
        public string ConvertCatalogName(string sqlCatalogName, CodeGenConfig config) => 
            ConvertName(sqlCatalogName, config, s => s.Pascalize());

        public string ConvertSchemaName(string sqlSchemaName, CodeGenConfig config, string enclosingType) =>
            ConvertName(sqlSchemaName, config, s => s.Pascalize());

        public string ConvertTableName(string sqlTableName, CodeGenConfig config, string enclosingType)
        {
            sqlTableName = CleanseDatabaseObjectName(sqlTableName, config);
            return ConvertName(sqlTableName, config, s => s.Pascalize().Singularize(false));
        }

        public string ConvertColumnName(string sqlColumnName, CodeGenConfig config, HashSet<string> additionalNamesToAvoid) =>
            ConvertName(sqlColumnName, config, s => s.Pascalize().Singularize(false), additionalNamesToAvoid);

        private string ConvertName(string name, CodeGenConfig config, Func<string, string> humanizerFunc, 
            HashSet<string> additionalNamesToAvoid = null)
        {
            //Ensure new name is not a Languages keyword or a SchemaTypist keyword.
            //If so, then disambiguate appropriately. 

            var proposedName = humanizerFunc(name);
            var programmingLanguage = Languages.CSharp.Language;
            var schemaTypistDsl = Languages.SchemaTypist;
            return Disambiguator.DisambiguateIdentifier(proposedName,
                s => programmingLanguage.HasConflict(s) || schemaTypistDsl.HasConflict(s), additionalNamesToAvoid);
        }

        private string CleanseDatabaseObjectName(string dbObjectName, CodeGenConfig config)
        {
            if (string.IsNullOrWhiteSpace(dbObjectName) 
                || (string.IsNullOrWhiteSpace(config.StripPrefix) && string.IsNullOrWhiteSpace(config.StripSuffix))) return dbObjectName;
            
            var stripPrefix = string.IsNullOrWhiteSpace(config.StripPrefix) ? new string[]{} : config.StripPrefix?.Split(',');
            var stripSuffix = string.IsNullOrWhiteSpace(config.StripSuffix) ? new string[]{} : config.StripSuffix?.Split(',');

            var retVal = stripPrefix.Aggregate(dbObjectName, (current, prefix) => current.StartsWith(prefix) ? current.Replace(prefix, "") : current);
            retVal = stripSuffix.Aggregate(retVal, (current, suffix) => current.EndsWith(suffix) ? current.Replace(suffix, "") : current);
            return retVal;
        }




    }
}