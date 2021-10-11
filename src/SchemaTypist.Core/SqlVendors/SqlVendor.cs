using System;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.Utilities;

namespace SchemaTypist.Core.SqlVendors
{
    internal static partial class SqlVendor
    {
        private static ISqlDialect GetSqlDialect(SqlVendorType vendorType)
        {
            return vendorType switch
            {
                SqlVendorType.MicrosoftSqlServer => MicrosoftSqlServer,
                SqlVendorType.PostgreSql => PostgreSql,
                _ => throw new NotImplementedException()
            };
        }

        public static string DisambiguateSqlIdentifier(string sqlIdentifier, CodeGenConfig config)
        {
            var sqlDialect = GetSqlDialect(config.Vendor);
            return Disambiguator.DisambiguateIdentifier(sqlIdentifier, s => sqlDialect.HasConflict(s));
        }

        public static string BuildQualifiedName(TabularStructure tableStructure, CodeGenConfig config)
        {
            var sqlDialect = GetSqlDialect(config.Vendor);
            return sqlDialect.BuildQualifiedName(tableStructure);
        }

        public static string DetermineDotNetDataType(string sqlDataType, bool isNullable, CodeGenConfig config)
        {
            var sqlDialect = GetSqlDialect(config.Vendor);
            return sqlDialect.DetermineDotNetDataType(sqlDataType, isNullable);

        }
    }
}
