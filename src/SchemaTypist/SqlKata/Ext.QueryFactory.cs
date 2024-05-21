using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchemaTypist.DatabaseMetadata;
using SqlKata.Execution;
using Dapper;
using SqlKata;

namespace SchemaTypist.SqlKata
{
    public static partial class Ext
    {
        public static async Task<IEnumerable<T1>> GetMultiMappedAsync<T1, T2>(this QueryFactory db, Query q, 
            Func<T1, T2, T1> transform, ColumnDefinition splitOn)
        {
            var sql = db.Compiler.Compile(q).Sql;
            return await db.Connection.QueryAsync(sql, transform, splitOn: splitOn.Declaration__);
        }
    }
}