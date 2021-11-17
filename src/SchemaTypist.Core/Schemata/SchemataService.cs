using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Npgsql;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Schemata.Dto;
using SchemaTypist.Core.Schemata.Mapping;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace SchemaTypist.Core.Schemata
{
    static class SchemataService
    {
        static SchemataService()
        {
            DapperTypeMapping.Init();
        }

        public static async Task<IEnumerable<ColumnsDto>> ExtractDbMetadata(CodeGenConfig config)
        {
            var metadataQueries = new SchemataQueries(config);
            (var connection, var compiler) = GetDbSpecificLibraries(config);
            var db = new QueryFactory(connection, compiler);
            var q = metadataQueries.InspectTables();
            var sql = compiler.Compile(q).RawSql;
            Console.WriteLine(sql);
            var ts = await db.GetAsync<ColumnsDto>(q);
            return ts;
        }

        private static (IDbConnection, Compiler) GetDbSpecificLibraries(CodeGenConfig config)
        {
            (IDbConnection, Compiler) retVal = config.Vendor switch
            {
                SqlVendorType.MicrosoftSqlServer => (new SqlConnection(config.ConnectionString), new SqlServerCompiler()),
                SqlVendorType.PostgreSql => (new NpgsqlConnection(config.ConnectionString), new PostgresCompiler()),
                _ => throw new InvalidOperationException()
            };
            return retVal;
        }
    }
}
