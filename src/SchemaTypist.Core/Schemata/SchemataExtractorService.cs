using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Schemata.Dto;
using SchemaTypist.Core.Schemata.Mapping;
using SchemaTypist.Core.SqlVendors;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace SchemaTypist.Core.Schemata
{
    internal class SchemataExtractorService : ISchemataExtractorService
    {
        private readonly ISqlVendorService _sqlVendor;
        static SchemataExtractorService()
        {
            DapperTypeMapping.Init();
        }

        public SchemataExtractorService(ISqlVendorService sqlVendor)
        {
            _sqlVendor = sqlVendor;
        }

        public async Task<IEnumerable<ColumnsDto>> ExtractDbMetadata(CodeGenConfig config)
        {
            var metadataQueries = new SchemataQueries(config);
            var (connection, compiler) = GetDbSpecificLibraries(config);
            var db = new QueryFactory(connection, compiler);
            var q = metadataQueries.InspectTables();
            // var sql = compiler.Compile(q).RawSql;
            // Console.WriteLine(sql);
            var ts = await db.GetAsync<ColumnsDto>(q);
            return ts;
        }

        private (IDbConnection, Compiler) GetDbSpecificLibraries(CodeGenConfig config)
        {
            return _sqlVendor.GetDbInterfaceProviders(config);
        }
    }

    public interface ISchemataExtractorService
    {
        Task<IEnumerable<ColumnsDto>> ExtractDbMetadata(CodeGenConfig config);
    }
}
