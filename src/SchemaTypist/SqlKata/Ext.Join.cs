﻿using SchemaTypist.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.SqlKata
{
    public static partial class Ext
    {
        public static Join On(this Join join, ColumnDefinition first, ColumnDefinition second, string op = "=")
        {
            return join.On(first.QualifiedName__, second.QualifiedName__, op);
        }

        public static Join OrOn(this Join join, ColumnDefinition first, ColumnDefinition second, string op = "=")
        {
            return join.OrOn(first.QualifiedName__, second.QualifiedName__, op);
        }

    }
}
