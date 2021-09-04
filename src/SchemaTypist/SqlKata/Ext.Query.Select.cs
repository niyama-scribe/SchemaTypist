using System.Collections.Generic;
using System.Linq;
using SchemaTypist.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.SqlKata
{
    public static partial class Ext
    {
        public static Query Select(this Query q, params ColumnDefinition[] columns)
        {
            return q.Select(columns?.Select(c => c.Declaration__).ToArray());
        }

        public static Query Select(this Query q, IEnumerable<ColumnDefinition> columns)
        {
            return q.Select(columns.Select(c => c.Declaration__).ToArray());
        }
    }
}
