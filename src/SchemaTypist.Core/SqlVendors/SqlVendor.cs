using System;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.SqlVendors
{
    internal static partial class SqlVendor
    {
        public static ISqlDialect GetSqlDialect(SqlVendorType vendorType)
        {
            return vendorType switch
            {
                SqlVendorType.MicrosoftSqlServer => MicrosoftSqlServer,
                SqlVendorType.PostgreSql => PostgreSql,
                _ => throw new NotImplementedException()
            };
        }
    }
}
