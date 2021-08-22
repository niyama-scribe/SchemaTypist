using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.SqlVendors
{
    interface ISqlDialect
    {
        string DetermineDotNetDataType(string sqlDataType, bool isNullable);
        IEnumerable<string> Keywords { get; }
        IEnumerable<string> DataTypes { get; }
    }
}
