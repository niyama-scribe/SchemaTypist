using System;
using System.Collections.Generic;
using System.Text;
using SchemaTypist.Core.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.Core.SqlKata
{
    public static partial class Ext
    {
        public static Query Join(this Query q, TabularDefinition table, Func<Join, Join> callback,
            string type = "inner join")
        {
            return q.Join(table.QualifiedName__, callback, type);
        }

        public static Query LeftJoin(this Query q, TabularDefinition table, ColumnDefinition first, ColumnDefinition second, string op = "=")
        {
            return q.LeftJoin(table.QualifiedName__, first.QualifiedName__, second.QualifiedName__, op);
        }

        public static Query LeftJoin(this Query q, TabularDefinition table, Func<Join, Join> callback)
        {
            return q.LeftJoin(table.QualifiedName__, callback);
        }

        public static Query RightJoin(this Query q, TabularDefinition table, ColumnDefinition first, ColumnDefinition second, string op = "=")
        {
            return q.RightJoin(table.QualifiedName__, first.QualifiedName__, second.QualifiedName__, op);
        }

        public static Query RightJoin(this Query q, TabularDefinition table, Func<Join, Join> callback)
        {
            return q.RightJoin(table.QualifiedName__, callback);
        }

        public static Query CrossJoin(this Query q, TabularDefinition table)
        {
            return q.CrossJoin(table.QualifiedName__);
        }

    }
}
