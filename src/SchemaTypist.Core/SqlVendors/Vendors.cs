using System;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.SqlVendors
{
    static partial class Vendors
    {
        public static ISqlDialect GetSqlDialect(SqlVendorType vendorType)
        {
            ISqlDialect retVal;
            switch (vendorType)
            {
                case SqlVendorType.MicrosoftSqlServer:
                    retVal = MicrosoftSqlServer.Dialect;
                    break;
                default:
                    throw new NotImplementedException();
            }
            return retVal;
        }
    }
}
