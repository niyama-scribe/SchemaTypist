using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.SqlVendors;

namespace SchemaTypist.Core.SqlVendors
{
    internal static partial class SqlVendor
    {
        public static ISqlDialect PostgreSql { get; } = new PostgresDialect();
        private class PostgresDialect : ISqlDialect
        {
            public IEnumerable<string> Keywords { get; } = Enumerable.Empty<string>();
            public IEnumerable<string> DataTypes { get; } = Enumerable.Empty<string>();
            public bool HasConflict(string proposedName)
            {
                return false;
            }

            public string DetermineDotNetDataType(string sqlDataType, bool isNullable)
            {
                return "string";
            }

            public string BuildQualifiedName(TabularStructure tabularStructure)
            {
                //Fully qualified name for tabular structures in pgsql is schema.tableName.  Cross-database references are not implemented
                return $"{tabularStructure.SqlSchema}.{tabularStructure.SqlName}";
            }
        }
    }
}
