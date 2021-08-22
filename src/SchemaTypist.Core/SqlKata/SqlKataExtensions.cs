using SchemaTypist.Core.DatabaseMetadata;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.Core.SqlKata
{
    public static class SqlKataExtensions
    {
        public static Query From<T>(this BaseQuery<Query> query, T tabularDefinition) where T : TabularDefinition
        {
            return query.From(tabularDefinition.Declaration__);
        }

        public static Query LeftJoin<T>(this Query query,
            T tabularDefinition, Func<Join, Join> onCallback) where T : TabularDefinition
        {
            return query.LeftJoin(tabularDefinition.Declaration__, onCallback);
        }

        public static Query LeftJoin<T>(this Query query,
            T tabularDefinition, string first, string second, string op = "=") where T : TabularDefinition
        {
            return query.LeftJoin(tabularDefinition.Declaration__, first, second, op);
        }

        public static Query Select(this Query query, params ColumnDefinition[] columnDefinitions)
        {
            return query.Select(columnDefinitions.Select(bcd => bcd.Declaration__).ToArray());
        }

        public static Query OrderBy(this Query query, params ColumnDefinition[] columnDefinitions)
        {
            return query.OrderBy(columnDefinitions.Select(bcd => bcd.QualifiedName__).ToArray());
        }

        public static Join On(this Join join, ColumnDefinition first, ColumnDefinition second, String op = "=")
        {
            return join.On(first.QualifiedName__, second.QualifiedName__, op);
        }

        public static Join Where(this BaseQuery<Join> join, ColumnDefinition column, String op, Object value)
        {
            return join.Where(column.QualifiedName__, op, value);
        }



    }
}
