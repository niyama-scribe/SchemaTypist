using System;
using System.Collections.Generic;
using System.Linq;
using SchemaTypist.DatabaseMetadata;
using SqlKata;

namespace SchemaTypist.SqlKata
{
    public static partial class Ext
    {
        public static Query Having(this Query q, ColumnDefinition column, string op, object value)
        {
            return q.Having(column.QualifiedName__, op, value);
        }

        public static Query HavingNot(this Query q, ColumnDefinition column, string op, object value)
        {
            return q.HavingNot(column.QualifiedName__, op, value);
        }

        public static Query OrHaving(this Query q, ColumnDefinition column, string op, object value)
        {
            return q.OrHaving(column.QualifiedName__, op, value);
        }

        public static Query OrHavingNot(this Query q, ColumnDefinition column, string op, object value)
        {
            return q.OrHavingNot(column.QualifiedName__, op, value);
        }

        public static Query Having(this Query q, ColumnDefinition column, object value)
        {
            return q.Having(column.QualifiedName__, value);
        }

        public static Query HavingNot(this Query q, ColumnDefinition column, object value)
        {
            return q.HavingNot(column.QualifiedName__, value);
        }

        public static Query OrHaving(this Query q, ColumnDefinition column, object value)
        {
            return q.OrHaving(column.QualifiedName__, value);
        }

        public static Query OrHavingNot(this Query q, ColumnDefinition column, object value)
        {
            return q.OrHavingNot(column.QualifiedName__, value);
        }

        public static Query Having(this Query q, IEnumerable<KeyValuePair<ColumnDefinition, object>> values)
        {
            return q.Having(values?.Select(kvp => new KeyValuePair<string, object>(kvp.Key.QualifiedName__, kvp.Value)));
        }

        public static Query HavingColumns(this Query q, ColumnDefinition first, string op, ColumnDefinition second)
        {
            return q.HavingColumns(first.QualifiedName__, op, second.QualifiedName__);
        }

        public static Query OrHavingColumns(this Query q, ColumnDefinition first, string op, ColumnDefinition second)
        {
            return q.OrHavingColumns(first.QualifiedName__, op, second.QualifiedName__);
        }

        public static Query HavingNull(this Query q, ColumnDefinition column)
        {
            return q.HavingNull(column.QualifiedName__);
        }

        public static Query OrHavingNull(this Query q, ColumnDefinition column)
        {
            return q.OrHavingNull(column.QualifiedName__);
        }

        public static Query HavingNotNull(this Query q, ColumnDefinition column)
        {
            return q.HavingNotNull(column.QualifiedName__);
        }

        public static Query OrHavingNotNull(this Query q, ColumnDefinition column)
        {
            return q.OrHavingNotNull(column.QualifiedName__);
        }

        public static Query HavingTrue(this Query q, ColumnDefinition column)
        {
            return q.HavingTrue(column.QualifiedName__);
        }

        public static Query OrHavingTrue(this Query q, ColumnDefinition column)
        {
            return q.OrHavingTrue(column.QualifiedName__);
        }

        public static Query HavingFalse(this Query q, ColumnDefinition column)
        {
            return q.HavingFalse(column.QualifiedName__);
        }

        public static Query OrHavingFalse(this Query q, ColumnDefinition column)
        {
            return q.OrHavingFalse(column.QualifiedName__);
        }

        public static Query HavingLike(this Query q, ColumnDefinition column, object value, 
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.HavingLike(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query HavingNotLike(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.HavingNotLike(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query OrHavingLike(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.OrHavingLike(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query OrHavingNotLike(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.OrHavingNotLike(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query HavingStarts(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.HavingStarts(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query HavingNotStarts(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.HavingNotStarts(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query OrHavingStarts(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.OrHavingStarts(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query OrHavingNotStarts(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.OrHavingNotStarts(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query HavingEnds(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.HavingEnds(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query HavingNotEnds(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.HavingNotEnds(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query OrHavingEnds(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.OrHavingEnds(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query OrHavingNotEnds(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.OrHavingNotEnds(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query HavingContains(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.HavingContains(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query HavingNotContains(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.HavingNotContains(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query OrHavingContains(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.OrHavingContains(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query OrHavingNotContains(this Query q, ColumnDefinition column, object value,
            bool caseSensitive = false, string escapeCharacter = null)
        {
            return q.OrHavingNotContains(column.QualifiedName__, value, caseSensitive, escapeCharacter);
        }

        public static Query HavingBetween<T>(this Query q, ColumnDefinition column, T lower, T higher)
        {
            return q.HavingBetween(column.QualifiedName__, lower, higher);
        }

        public static Query OrHavingBetween<T>(this Query q, ColumnDefinition column, T lower, T higher)
        {
            return q.OrHavingBetween(column.QualifiedName__, lower, higher);
        }

        public static Query HavingNotBetween<T>(this Query q, ColumnDefinition column, T lower, T higher)
        {
            return q.HavingNotBetween(column.QualifiedName__, lower, higher);
        }

        public static Query OrHavingNotBetween<T>(this Query q, ColumnDefinition column, T lower, T higher)
        {
            return q.OrHavingNotBetween(column.QualifiedName__, lower, higher);
        }

        public static Query HavingIn<T>(this Query q, ColumnDefinition column, IEnumerable<T> values)
        {
            return q.HavingIn(column.QualifiedName__, values);
        }

        public static Query OrHavingIn<T>(this Query q, ColumnDefinition column, IEnumerable<T> values)
        {
            return q.OrHavingIn(column.QualifiedName__, values);
        }

        public static Query HavingNotIn<T>(this Query q, ColumnDefinition column, IEnumerable<T> values)
        {
            return q.HavingNotIn(column.QualifiedName__, values);
        }

        public static Query OrHavingNotIn<T>(this Query q, ColumnDefinition column, IEnumerable<T> values)
        {
            return q.OrHavingNotIn(column.QualifiedName__, values);
        }

        public static Query HavingIn(this Query q, ColumnDefinition column, Query query)
        {
            return q.HavingIn(column.QualifiedName__, query);
        }

        public static Query HavingIn(this Query q, ColumnDefinition column, Func<Query, Query> callback)
        {
            return q.HavingIn(column.QualifiedName__, callback);
        }

        public static Query OrHavingIn(this Query q, ColumnDefinition column, Query query)
        {
            return q.OrHavingIn(column.QualifiedName__, query);
        }

        public static Query OrHavingIn(this Query q, ColumnDefinition column, Func<Query, Query> callback)
        {
            return q.OrHavingIn(column.QualifiedName__, callback);
        }

        public static Query HavingNotIn(this Query q, ColumnDefinition column, Query query)
        {
            return q.HavingNotIn(column.QualifiedName__, query);
        }

        public static Query HavingNotIn(this Query q, ColumnDefinition column, Func<Query, Query> callback)
        {
            return q.HavingNotIn(column.QualifiedName__, callback);
        }

        public static Query OrHavingNotIn(this Query q, ColumnDefinition column, Query query)
        {
            return q.OrHavingNotIn(column.QualifiedName__, query);
        }

        public static Query OrHavingNotIn(this Query q, ColumnDefinition column, Func<Query, Query> callback)
        {
            return q.OrHavingNotIn(column.QualifiedName__, callback);
        }

        public static Query Having(this Query q, ColumnDefinition column, string op, Func<Query, Query> callback)
        {
            return q.Having(column.QualifiedName__, op, callback);
        }

        public static Query Having(this Query q, ColumnDefinition column, string op, Query query)
        {
            return q.Having(column.QualifiedName__, op, query);
        }

        public static Query OrHaving(this Query q, ColumnDefinition column, string op, Func<Query, Query> callback)
        {
            return q.OrHaving(column.QualifiedName__, op, callback);
        }

        public static Query OrHaving(this Query q, ColumnDefinition column, string op, Query query)
        {
            return q.OrHaving(column.QualifiedName__, op, query);
        }

        public static Query HavingDatePart(this Query q, string part, ColumnDefinition column, string op,
            object value)
        {
            return q.HavingDatePart(part, column.QualifiedName__, op, value);
        }

        public static Query HavingNotDatePart(this Query q, string part, ColumnDefinition column, string op,
            object value)
        {
            return q.HavingNotDatePart(part, column.QualifiedName__, op, value);
        }

        public static Query OrHavingDatePart(this Query q, string part, ColumnDefinition column, string op,
            object value)
        {
            return q.OrHavingDatePart(part, column.QualifiedName__, op, value);
        }

        public static Query OrHavingNotDatePart(this Query q, string part, ColumnDefinition column, string op,
            object value)
        {
            return q.OrHavingNotDatePart(part, column.QualifiedName__, op, value);
        }

        public static Query HavingDate(this Query q, ColumnDefinition column, string op,
            object value)
        {
            return q.HavingDate(column.QualifiedName__, op, value);
        }

        public static Query HavingNotDate(this Query q, ColumnDefinition column, string op,
            object value)
        {
            return q.HavingNotDate(column.QualifiedName__, op, value);
        }

        public static Query OrHavingDate(this Query q, ColumnDefinition column, string op,
            object value)
        {
            return q.OrHavingDate(column.QualifiedName__, op, value);
        }

        public static Query OrHavingNotDate(this Query q, ColumnDefinition column, string op,
            object value)
        {
            return q.OrHavingNotDate(column.QualifiedName__, op, value);
        }

        public static Query HavingTime(this Query q, ColumnDefinition column, string op,
            object value)
        {
            return q.HavingTime(column.QualifiedName__, op, value);
        }

        public static Query HavingNotTime(this Query q, ColumnDefinition column, string op,
            object value)
        {
            return q.HavingNotTime(column.QualifiedName__, op, value);
        }

        public static Query OrHavingTime(this Query q, ColumnDefinition column, string op,
            object value)
        {
            return q.OrHavingTime(column.QualifiedName__, op, value);
        }

        public static Query OrHavingNotTime(this Query q, ColumnDefinition column, string op,
            object value)
        {
            return q.OrHavingNotTime(column.QualifiedName__, op, value);
        }

        public static Query HavingDatePart(this Query q, string part, ColumnDefinition column, 
            object value)
        {
            return q.HavingDatePart(part, column.QualifiedName__, value);
        }

        public static Query HavingNotDatePart(this Query q, string part, ColumnDefinition column, 
            object value)
        {
            return q.HavingNotDatePart(part, column.QualifiedName__, value);
        }

        public static Query OrHavingDatePart(this Query q, string part, ColumnDefinition column, 
            object value)
        {
            return q.OrHavingDatePart(part, column.QualifiedName__, value);
        }

        public static Query OrHavingNotDatePart(this Query q, string part, ColumnDefinition column, 
            object value)
        {
            return q.OrHavingNotDatePart(part, column.QualifiedName__, value);
        }

        public static Query HavingDate(this Query q, ColumnDefinition column, 
            object value)
        {
            return q.HavingDate(column.QualifiedName__, value);
        }

        public static Query HavingNotDate(this Query q, ColumnDefinition column, 
            object value)
        {
            return q.HavingNotDate(column.QualifiedName__, value);
        }

        public static Query OrHavingDate(this Query q, ColumnDefinition column, 
            object value)
        {
            return q.OrHavingDate(column.QualifiedName__, value);
        }

        public static Query OrHavingNotDate(this Query q, ColumnDefinition column, 
            object value)
        {
            return q.OrHavingNotDate(column.QualifiedName__, value);
        }

        public static Query HavingTime(this Query q, ColumnDefinition column, 
            object value)
        {
            return q.HavingTime(column.QualifiedName__, value);
        }

        public static Query HavingNotTime(this Query q, ColumnDefinition column, 
            object value)
        {
            return q.HavingNotTime(column.QualifiedName__, value);
        }

        public static Query OrHavingTime(this Query q, ColumnDefinition column, 
            object value)
        {
            return q.OrHavingTime(column.QualifiedName__, value);
        }

        public static Query OrHavingNotTime(this Query q, ColumnDefinition column, 
            object value)
        {
            return q.OrHavingNotTime(column.QualifiedName__, value);
        }


    }
}
