using System;
using System.Collections.Generic;
using System.Text;
using SchemaTypist.Core.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.Core.SqlKata
{
    public static partial class Ext
    {
        public static TQ From<TQ>(this BaseQuery<TQ> bq, TabularDefinition table) where TQ : BaseQuery<TQ>
        {
            return bq.From(table.Declaration__);
        }
    }
}
