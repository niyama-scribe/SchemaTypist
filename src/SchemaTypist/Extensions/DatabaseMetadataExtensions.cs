using System;
using System.Collections.Generic;
using System.Text;
using SchemaTypist.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.Extensions
{
    public static class DatabaseMetadataExtensions
    {
        public static Query AsQuery(this TabularDefinition table)
        {
            return new Query(table.Usage__);
        }
    }
}
