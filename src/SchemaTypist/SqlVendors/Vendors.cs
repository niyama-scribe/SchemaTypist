using SchemaTypist.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.SqlVendors
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
