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
        public static Query Select(this Query q, params ColumnDefinition[] columns)
        {
            return q.Select(columns?.Select(c => c.QualifiedName__).ToArray());
        }

        public static Query Select(this Query q, IEnumerable<ColumnDefinition> columns)
        {
            return q.Select(columns.Select(c => c.QualifiedName__).ToArray());
        }
    }
}
