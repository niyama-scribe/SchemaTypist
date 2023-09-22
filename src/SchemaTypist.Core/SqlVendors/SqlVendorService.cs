using System;
using System.Data;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Language;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.Utilities;
using SqlKata.Compilers;

namespace SchemaTypist.Core.SqlVendors
{
    internal class SqlVendorService : ISqlVendorService
    {
        private readonly Lazy<ISqlVendorPluginLoader> _pluginLoader;

        public SqlVendorService(ISqlVendorPluginLoader pluginLoader)
        {
            _pluginLoader = new Lazy<ISqlVendorPluginLoader>(() =>
            {
                pluginLoader.LoadRegisteredVendors();
                return pluginLoader;
            });
        }

        public string DisambiguateSqlIdentifier(string sqlIdentifier, CodeGenConfig config)
        {
            var sqlDialect = GetSqlDialect(config.Vendor);
            return Disambiguator.DisambiguateIdentifier(sqlIdentifier, s => sqlDialect.HasConflict(s));
        }

        public string BuildQualifiedName(TabularStructure tableStructure, CodeGenConfig config)
        {
            var sqlDialect = GetSqlDialect(config.Vendor);
            return sqlDialect.BuildQualifiedName(tableStructure);
        }

        public string DetermineDotNetDataType(string sqlDataType, bool isNullable, CodeGenConfig config)
        {
            var sqlDialect = GetSqlDialect(config.Vendor);
            var dotNetDataType = sqlDialect.DetermineDotNetDataType(sqlDataType, isNullable);
            return Languages.CSharp.HandleNullability(dotNetDataType, isNullable, config);
        }

        public (IDbConnection, Compiler) GetDbInterfaceProviders(CodeGenConfig config)
        {
            return GetSqlVendor(config.Vendor).GetDbInterfaceProviders(config);
        }

        public string DetermineDefaultValue(string columnDefault, string dotnetDataType, CodeGenConfig config)
        {
            if (string.IsNullOrEmpty(columnDefault)) return null;

            var rawDefaultStr = GetSqlDialect(config.Vendor).DetermineDefaultValue(columnDefault);

            if (string.IsNullOrEmpty(rawDefaultStr)) return null;
            if (rawDefaultStr is "null") return rawDefaultStr;

            //Now represent literals as per mapped datatype
            var coreDatatype = dotnetDataType.Replace("?", "").ToLower();

            return coreDatatype switch
            {
                "char" => $"'{rawDefaultStr}'",
                "string" => $"\"{rawDefaultStr}\"",
                "double" or "short" or "int" or "long" => rawDefaultStr,
                "decimal" => $"(decimal) {rawDefaultStr}",
                "float" => $"{rawDefaultStr}f",
                //"datetime" => $"DateTime.Parse(\"{rawDefaultStr}\")",

                _ => null
            };
        }

        public IMetadataQueryBuilder GetMetadataQueryBuilder(CodeGenConfig config)
        {
            return GetSqlVendor(config.Vendor).MetadataQueryBuilder;
        }

        private ISqlVendor GetSqlVendor(SqlVendorType vendorType)
        {
            return _pluginLoader.Value.GetSqlVendor(vendorType);
        }


        private ISqlDialect GetSqlDialect(SqlVendorType vendorType)
        {
            return GetSqlVendor(vendorType)?.Dialect;
        }
    }

    public interface ISqlVendorService
    {
        string DisambiguateSqlIdentifier(string sqlIdentifier, CodeGenConfig config);
        string BuildQualifiedName(TabularStructure tableStructure, CodeGenConfig config);
        string DetermineDotNetDataType(string sqlDataType, bool isNullable, CodeGenConfig config);
        (IDbConnection, Compiler) GetDbInterfaceProviders(CodeGenConfig config);
        string DetermineDefaultValue(string columnDefault, string mappedDotnetDatatype, CodeGenConfig config);
        IMetadataQueryBuilder GetMetadataQueryBuilder(CodeGenConfig config);
    }
}