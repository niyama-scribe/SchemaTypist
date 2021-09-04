using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
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
            var connection = new SqlConnection(config.ConnectionString);
            var compiler = new SqlServerCompiler();
            var db = new QueryFactory(connection, compiler);
            var ts = await db.GetAsync<ColumnsDto>(metadataQueries.InspectTables());
            return ts;
        }
    }
}
