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
            return new Query(table.QualifiedName__);
        }

        public static Query For<T>(this Query q, T t) where T : TabularDefinition
        {
            return new Query(t.QualifiedName__);
        }
    }
}
