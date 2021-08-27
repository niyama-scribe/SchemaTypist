using System;
using System.Collections.Generic;
using System.Text;
using SchemaTypist.Core.DatabaseMetadata;
using SqlKata;
using System.Linq;

namespace SchemaTypist.Core.SqlKata
{
    public static partial class Ext
    {
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
