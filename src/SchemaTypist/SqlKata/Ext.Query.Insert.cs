using System.Collections.Generic;
using System.Linq;
using SchemaTypist.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.SqlKata
{
    public static partial class Ext
    {
        public static Query AsInsert(this Query q, IEnumerable<ColumnDefinition> columns,
            IEnumerable<object> values)
        {
            return q.AsInsert(columns.Select(c => c.ColumnName__), values);
        }

        public static Query AsInsert(this Query q, IEnumerable<KeyValuePair<ColumnDefinition, object>> values)
        {
            return q.AsInsert(values.Select(kvp => new KeyValuePair<string, object>(kvp.Key.ColumnName__, kvp.Value)));
        }

        public static Query AsInsert(this Query q, IEnumerable<ColumnDefinition> columns,
            IEnumerable<IEnumerable<object>> rowsValues)
        {
            return q.AsInsert(columns.Select(c => c.ColumnName__), rowsValues);
        }

        public static Query AsInsert(this Query q, IEnumerable<ColumnDefinition> columns, Query query)
        {
            return q.AsInsert(columns.Select(c => c.ColumnName__), query);
        }

    }
}
