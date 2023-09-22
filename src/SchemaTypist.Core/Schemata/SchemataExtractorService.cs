using System.Data;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<SchemataMetadata> ExtractDbMetadata(CodeGenConfig config)
        {
            var metadataQueryBuilder = _sqlVendor.GetMetadataQueryBuilder(config);
            var (connection, compiler) = GetDbSpecificLibraries(config);
            var db = new QueryFactory(connection, compiler);
            var tablesInspectionQuery = metadataQueryBuilder.BuildTablesQuery();
            //var routinesInspectionQuery = metadataQueryBuilder.BuildRoutinesInspectionQuery();
            //var routinesTableValuedParametersInspectionQuery =
            //    metadataQueryBuilder.BuildRoutinesTableValuedParametersInspectionQuery();
            //var routinesReturnTypesInspectionQuery = metadataQueryBuilder.BuildRoutinesReturnTypesInspectionQuery();
            return new SchemataMetadata
            {
                TablesMetadata = (await db.GetAsync<ColumnsDto>(tablesInspectionQuery)).ToList()
            };
        }

        private (IDbConnection, Compiler) GetDbSpecificLibraries(CodeGenConfig config)
        {
            return _sqlVendor.GetDbInterfaceProviders(config);
        }
    }

    public interface ISchemataExtractorService
    {
        Task<SchemataMetadata> ExtractDbMetadata(CodeGenConfig config);
    }
}