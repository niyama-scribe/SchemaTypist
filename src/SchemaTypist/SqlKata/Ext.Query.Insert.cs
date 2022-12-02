using System.Collections.Generic;
using System.Linq;
using SchemaTypist.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.SqlKata
{
    public static partial class Ext
    {
        public static Query AsInsert(this Query q, IEnumerable<ColumnDefinition> columns,
            IEnumerable<object> values, bool returnId = false)
        {
            var kvpEnumerable =
                columns.Zip(values, (col, val) => new KeyValuePair<string, object>(col.ColumnName__, val));
            return q.AsInsert(kvpEnumerable, returnId);
        }

        public static Query AsInsert(this Query q, IEnumerable<KeyValuePair<ColumnDefinition, object>> values, bool returnId = false)
        {
            return q.AsInsert(values.Select(kvp => new KeyValuePair<string, object>(kvp.Key.ColumnName__, kvp.Value)), returnId);
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
