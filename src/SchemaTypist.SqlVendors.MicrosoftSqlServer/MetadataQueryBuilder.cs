using System;
using SchemaTypist.Core.Schemata;
using SqlKata;

namespace SchemaTypist.SqlVendors.MicrosoftSqlServer
{
    internal class MetadataQueryBuilder : AnsiSqlMetadataQueryBuilder
    {
        public override Query BuildRoutinesQuery()
        {
            throw new NotImplementedException();
        }

        public override Query BuildTableValuedParametersQuery()
        {
            throw new NotImplementedException();
        }

        public override Query BuildRoutinesReturnTypesQuery()
        {
            throw new NotImplementedException();
        }
    }
}