using System.Collections.Generic;
using System.Data;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Language;
using SchemaTypist.Core.Model;
using SqlKata.Compilers;

namespace SchemaTypist.Core.SqlVendors
{
    public interface ISqlDialect : ILanguage
    {
        string DetermineDotNetDataType(string sqlDataType, bool isNullable);

        string BuildQualifiedName(TabularStructure tabularStructure);

        string DetermineDefaultValue(string columnDefault);
    }

    public interface ISqlVendor
    {
        SqlVendorType VendorType { get; }

        (IDbConnection, Compiler) GetDbInterfaceProviders(CodeGenConfig config);
        ISqlDialect Dialect { get; }
    }
}
