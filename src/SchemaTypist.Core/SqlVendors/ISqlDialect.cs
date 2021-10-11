using System.Collections.Generic;
using SchemaTypist.Core.Language;
using SchemaTypist.Core.Model;

namespace SchemaTypist.Core.SqlVendors
{
    internal interface ISqlDialect : ILanguage
    {
        string DetermineDotNetDataType(string sqlDataType, bool isNullable);

        string BuildQualifiedName(TabularStructure tabularStructure);
    }
}
