using SchemaTypist.Core.Schemata;
using SchemaTypist.Core.SqlVendors;
using SqlKata;

namespace SchemaTypist.SqlVendors.PostgreSql
{
    public class MetadataQueryBuilder : AnsiSqlMetadataQueryBuilder
    {
        public override Query BuildRoutinesQuery()
        {
            throw new System.NotImplementedException();
        }

        public override Query BuildTableValuedParametersQuery()
        {
            throw new System.NotImplementedException();
        }

        public override Query BuildRoutinesReturnTypesQuery()
        {
            throw new System.NotImplementedException();
        }
    }
}