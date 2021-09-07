using System.Collections.Generic;
using SchemaTypist.Core.Language;

namespace SchemaTypist.Core.SqlVendors
{
    internal interface ISqlDialect : ILanguage
    {
        string DetermineDotNetDataType(string sqlDataType, bool isNullable);
    }
}
