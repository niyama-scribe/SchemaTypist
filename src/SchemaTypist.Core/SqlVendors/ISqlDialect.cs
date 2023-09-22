using System.Data;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Language;
using SchemaTypist.Core.Model;
using SqlKata;
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
        ISqlDialect Dialect { get; }

        IMetadataQueryBuilder MetadataQueryBuilder { get; }

        (IDbConnection, Compiler) GetDbInterfaceProviders(CodeGenConfig config);
    }

    /// <summary>
    ///     Every SqlVendor should implement this interface.
    ///     This interface defines the contract for asking questions regarding database metadata.
    /// </summary>
    public interface IMetadataQueryBuilder
    {
        Query BuildTablesQuery();
        Query BuildRoutinesQuery();
        Query BuildTableValuedParametersQuery();
        Query BuildRoutinesReturnTypesQuery();
    }
}