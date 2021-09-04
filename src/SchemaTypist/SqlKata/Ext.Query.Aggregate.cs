using System.Linq;
using SchemaTypist.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.SqlKata
{
    public static partial class Ext
    {
        public static Query AsAggregate(this Query q, string type, ColumnDefinition[] columns = null)
        {
            return q.AsAggregate(type, columns?.Select(cd => cd.QualifiedName__).ToArray());
        }

        public static Query AsCount(this Query q, ColumnDefinition[] columns = null)
        {
            return q.AsCount(columns?.Select(cd => cd.QualifiedName__).ToArray());
        }

        public static Query AsAvg(this Query q, ColumnDefinition column)
        {
            return q.AsAvg(column.QualifiedName__);
        }

        public static Query AsAverage(this Query q, ColumnDefinition column)
        {
            return q.AsAverage(column.QualifiedName__);
        }

        public static Query AsSum(this Query q, ColumnDefinition column)
        {
            return q.AsSum(column.QualifiedName__);
        }

        public static Query AsMax(this Query q, ColumnDefinition column)
        {
            return q.AsMax(column.QualifiedName__);
        }

        public static Query AsMin(this Query q, ColumnDefinition column)
        {
            return q.AsMin(column.QualifiedName__);
        }

    }
}
