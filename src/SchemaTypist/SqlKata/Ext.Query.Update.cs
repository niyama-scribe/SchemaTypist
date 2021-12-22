using System.Collections.Generic;
using System.Linq;
using SchemaTypist.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.SqlKata
{
    public static partial class Ext
    {
        public static Query AsUpdate(this Query q, IEnumerable<ColumnDefinition> columns, IEnumerable<object> values)
        {
            return q.AsUpdate(columns.Select(c => c.ColumnName__), values);
        }

        public static Query AsUpdate(this Query q, IEnumerable<KeyValuePair<ColumnDefinition, object>> values)
        {
            return q.AsUpdate(values.Select(kvp => new KeyValuePair<string, object>(kvp.Key.ColumnName__, kvp.Value)));
        }

        public static Query AsIncrement(this Query q, ColumnDefinition column, int value = 1)
        {
            return q.AsIncrement(column.ColumnName__, value);
        }

        public static Query AsDecrement(this Query q, ColumnDefinition column, int value = 1)
        {
            return q.AsIncrement(column.ColumnName__, value);
        }
    }
}
