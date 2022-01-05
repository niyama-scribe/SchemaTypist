using System.Linq;
using SchemaTypist.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.SqlKata
{
    public static partial class Ext
    {
        public static Query AsQuery(this TabularDefinition table)
        {
            return new Query(table.QualifiedName__);
        }
        public static Query For<T>(this Query q, T t) where T : TabularDefinition
        {
            return new Query(t.QualifiedName__);
        }
        public static Query OrderBy(this Query q, params ColumnDefinition[] columns)
        {
            return q.OrderBy(columns?.Select(c => c.QualifiedName__).ToArray());
        }

        public static Query OrderByDesc(this Query q, params ColumnDefinition[] columns)
        {
            return q.OrderByDesc(columns?.Select(c => c.QualifiedName__).ToArray());
        }

        public static Query GroupBy(this Query q, params ColumnDefinition[] columns)
        {
            return q.GroupBy(columns?.Select(c => c.QualifiedName__).ToArray());
        }
    }
}
