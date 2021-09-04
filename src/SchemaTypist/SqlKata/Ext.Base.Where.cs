using System;
using System.Collections.Generic;
using System.Linq;
using SchemaTypist.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.SqlKata
{
    public static partial class Ext
    {
        public static TQ Where<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, string op, object value) where TQ:BaseQuery<TQ>
        {
            return baseQuery.Where(column.QualifiedName__, op, value);
        }

        public static TQ WhereNot<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNot(column.QualifiedName__, op, value);
        }

        public static TQ OrWhere<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhere(column.QualifiedName__, op, value);
        }

        public static Q OrWhereNot<Q>(this BaseQuery<Q> baseQuery, ColumnDefinition column, string op, object value) where Q : BaseQuery<Q>
        {
            return baseQuery.OrWhereNot(column.QualifiedName__, op, value);
        }

        public static TQ Where<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.Where(column.QualifiedName__, value);
        }

        public static TQ WhereNot<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNot(column.QualifiedName__, value);
        }

        public static TQ OrWhere<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhere(column.QualifiedName__, value);
        }

        public static TQ OrWhereNot<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNot(column.QualifiedName__, value);
        }

        public static TQ Where<TQ>(this BaseQuery<TQ> baseQuery, IEnumerable<KeyValuePair<ColumnDefinition,object>> values) where TQ : BaseQuery<TQ>
        {
            return baseQuery.Where(values.Select(kvp => new KeyValuePair<string, object>(kvp.Key.QualifiedName__, kvp.Value)));
        }

        public static TQ WhereColumns<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition first, string op, ColumnDefinition second) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereColumns(first.QualifiedName__, op, second.QualifiedName__);
        }

        public static TQ OrWhereColumns<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition first, string op, ColumnDefinition second) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereColumns(first.QualifiedName__, op, second.QualifiedName__);
        }

        public static TQ WhereNull<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNull(column.QualifiedName__);
        }

        public static TQ WhereNotNull<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotNull(column.QualifiedName__);
        }

        public static TQ OrWhereNull<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNull(column);
        }

        public static TQ OrWhereNotNull<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotNull(column.QualifiedName__);
        }

        public static TQ WhereTrue<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereTrue(column.QualifiedName__);
        }

        public static TQ OrWhereTrue<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereTrue(column.QualifiedName__);
        }

        public static TQ WhereFalse<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereFalse(column.QualifiedName__);
        }

        public static TQ OrWhereFalse<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereFalse(column.QualifiedName__);
        }

        public static TQ WhereLike<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive=false, string escapeCharacter=null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereLike(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ WhereNotLike<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotLike(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ OrWhereLike<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereLike(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ OrWhereNotLike<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotLike(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ WhereStarts<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereStarts(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ WhereNotStarts<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotStarts(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ OrWhereStarts<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereStarts(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ OrWhereNotStarts<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotStarts(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ WhereEnds<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereEnds(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ WhereNotEnds<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotEnds(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ OrWhereEnds<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereEnds(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ OrWhereNotEnds<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotEnds(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ WhereContains<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereContains(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ WhereNotContains<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotContains(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ OrWhereContains<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereContains(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ OrWhereNotContains<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, object value, bool caseSensitive = false, string escapeCharacter = null) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotContains(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static TQ WhereBetween<TQ, T>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, T lower, T higher) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereBetween(column.QualifiedName__, lower, higher);
        }

        public static TQ OrWhereBetween<TQ, T>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, T lower, T higher) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereBetween(column.QualifiedName__, lower, higher);
        }

        public static TQ WhereNotBetween<TQ, T>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, T lower, T higher) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotBetween(column.QualifiedName__, lower, higher);
        }

        public static TQ OrWhereNotBetween<TQ, T>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, T lower, T higher) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotBetween(column.QualifiedName__, lower, higher);
        }

        public static TQ WhereIn<TQ, T>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, IEnumerable<T> values) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereIn(column.QualifiedName__, values);
        }

        public static TQ OrWhereIn<TQ, T>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, IEnumerable<T> values) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereIn(column.QualifiedName__, values);
        }

        public static TQ WhereNotIn<TQ, T>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, IEnumerable<T> values) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotIn(column.QualifiedName__, values);
        }

        public static TQ OrWhereNotIn<TQ, T>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, IEnumerable<T> values) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotIn(column.QualifiedName__, values);
        }

        public static TQ WhereIn<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, Query query) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereIn(column.QualifiedName__, query);
        }

        public static TQ WhereIn<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, Func<Query, Query> callback) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereIn(column.QualifiedName__, callback);
        }

        public static TQ OrWhereIn<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, Query query) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereIn(column.QualifiedName__, query);
        }

        public static TQ OrWhereIn<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, Func<Query, Query> callback) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereIn(column.QualifiedName__, callback);
        }

        public static TQ WhereNotIn<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, Query query) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotIn(column.QualifiedName__, query);
        }

        public static TQ WhereNotIn<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, Func<Query, Query> callback) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotIn(column.QualifiedName__, callback);
        }

        public static TQ OrWhereNotIn<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, Query query) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotIn(column.QualifiedName__, query);
        }

        public static TQ OrWhereNotIn<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, Func<Query, Query> callback) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotIn(column.QualifiedName__, callback);
        }

        public static TQ Where<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, string op, Func<TQ, TQ> callback) where TQ : BaseQuery<TQ>
        {
            return baseQuery.Where(column.QualifiedName__, op, callback);
        }

        public static TQ Where<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, string op, Query query) where TQ : BaseQuery<TQ>
        {
            return baseQuery.Where(column.QualifiedName__, op, query);
        }

        public static TQ OrWhere<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, string op, Func<Query, Query> callback) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhere(column.QualifiedName__, op, callback);
        }

        public static TQ OrWhere<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column, string op, Query query) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhere(column.QualifiedName__, op, query);
        }

        public static TQ WhereDatePart<TQ>(this BaseQuery<TQ> baseQuery, string part, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereDatePart(part, column.QualifiedName__, op, value);
        }

        public static TQ OrWhereDatePart<TQ>(this BaseQuery<TQ> baseQuery, string part, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereDatePart(part, column.QualifiedName__, op, value);
        }

        public static TQ WhereNotDatePart<TQ>(this BaseQuery<TQ> baseQuery, string part, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotDatePart(part, column.QualifiedName__, op, value);
        }

        public static TQ OrWhereNotDatePart<TQ>(this BaseQuery<TQ> baseQuery, string part, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotDatePart(part, column.QualifiedName__, op, value);
        }

        public static TQ WhereDate<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereDate(column.QualifiedName__, op, value);
        }

        public static TQ OrWhereDate<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereDate(column.QualifiedName__, op, value);
        }

        public static TQ WhereNotDate<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotDate(column.QualifiedName__, op, value);
        }

        public static TQ OrWhereNotDate<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotDate(column.QualifiedName__, op, value);
        }

        public static TQ WhereTime<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereTime(column.QualifiedName__, op, value);
        }

        public static TQ OrWhereTime<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereTime(column.QualifiedName__, op, value);
        }

        public static TQ WhereNotTime<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotTime(column.QualifiedName__, op, value);
        }

        public static TQ OrWhereNotTime<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotTime(column.QualifiedName__, op, value);
        }

        public static TQ WhereDatePart<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereDatePart(column.QualifiedName__, op, value);
        }

        public static TQ OrWhereDatePart<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereDatePart(column.QualifiedName__, op, value);
        }

        public static TQ WhereNotDatePart<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotDatePart(column.QualifiedName__, op, value);
        }

        public static TQ OrWhereNotDatePart<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            string op, object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotDatePart(column.QualifiedName__, op, value);
        }

        public static TQ WhereDate<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereDate(column.QualifiedName__, value);
        }

        public static TQ OrWhereDate<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereDate(column.QualifiedName__, value);
        }

        public static TQ WhereNotDate<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotDate(column.QualifiedName__, value);
        }

        public static TQ OrWhereNotDate<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotDate(column.QualifiedName__, value);
        }

        public static TQ WhereTime<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereTime(column.QualifiedName__, value);
        }

        public static TQ OrWhereTime<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereTime(column.QualifiedName__, value);
        }

        public static TQ WhereNotTime<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.WhereNotTime(column.QualifiedName__, value);
        }

        public static TQ OrWhereNotTime<TQ>(this BaseQuery<TQ> baseQuery, ColumnDefinition column,
            object value) where TQ : BaseQuery<TQ>
        {
            return baseQuery.OrWhereNotTime(column.QualifiedName__, value);
        }


    }
}
