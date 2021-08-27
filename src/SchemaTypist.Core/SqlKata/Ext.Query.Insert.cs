using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchemaTypist.Core.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.Core.SqlKata
{
    public static partial class Ext
    {
        public static Query AsInsert(this Query q, IEnumerable<ColumnDefinition> columns,
            IEnumerable<object> values)
        {
            return q.AsInsert(columns.Select(c => c.QualifiedName__), values);
        }

        public static Query AsInsert(this Query q, IEnumerable<KeyValuePair<ColumnDefinition, object>> values)
        {
            return q.AsInsert(values.Select(kvp => new KeyValuePair<string, object>(kvp.Key.QualifiedName__, kvp.Value)));
        }

        public static Query AsInsert(this Query q, IEnumerable<ColumnDefinition> columns,
            IEnumerable<IEnumerable<object>> rowsValues)
        {
            return q.AsInsert(columns.Select(c => c.QualifiedName__), rowsValues);
        }

        public static Query AsInsert(this Query q, IEnumerable<ColumnDefinition> columns, Query query)
        {
            return q.AsInsert(columns.Select(c => c.QualifiedName__), query);
        }

    }
}
