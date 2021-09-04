using System.Collections.Generic;

namespace SchemaTypist.Core.SqlVendors
{
    interface ISqlDialect
    {
        string DetermineDotNetDataType(string sqlDataType, bool isNullable);
        IEnumerable<string> Keywords { get; }
        IEnumerable<string> DataTypes { get; }
    }
}
