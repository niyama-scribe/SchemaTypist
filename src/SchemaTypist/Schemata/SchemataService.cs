using SchemaTypist.Config;
using SchemaTypist.Schemata.Dto;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchemaTypist.Schemata.Mapping;

namespace SchemaTypist.Schemata
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
            var connection = new SqlConnection(config.ConnectionString);
            var compiler = new SqlServerCompiler();
            var db = new QueryFactory(connection, compiler);
            var ts = await db.GetAsync<ColumnsDto>(metadataQueries.InspectTables());
            return ts;
        }
    }
}
