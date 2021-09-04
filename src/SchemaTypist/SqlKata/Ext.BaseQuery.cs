using SchemaTypist.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.SqlKata
{
    public static partial class Ext
    {
        public static TQ From<TQ>(this BaseQuery<TQ> bq, TabularDefinition table) where TQ : BaseQuery<TQ>
        {
            return bq.From(table.Declaration__);
        }
    }
}
