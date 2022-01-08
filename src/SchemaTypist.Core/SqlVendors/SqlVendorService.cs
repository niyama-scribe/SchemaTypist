using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.Utilities;
using SqlKata.Compilers;

namespace SchemaTypist.Core.SqlVendors
{
    internal class SqlVendorService : ISqlVendorService
    {
       private readonly Lazy<ISqlVendorProvider> _provider;

       public SqlVendorService(ISqlVendorProvider provider)
       {
           _provider = new Lazy<ISqlVendorProvider>(() =>
           {
               provider.LoadRegisteredVendors();
               return provider;
           });
       }

       private ISqlVendor GetSqlVendor(SqlVendorType vendorType)
       {
           return _provider.Value.GetSqlVendor(vendorType);
       }


       private ISqlDialect GetSqlDialect(SqlVendorType vendorType)
       {
           return GetSqlVendor(vendorType)?.Dialect;
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
            return sqlDialect.DetermineDotNetDataType(sqlDataType, isNullable);

        }

        public (IDbConnection, Compiler) GetDbInterfaceProviders(CodeGenConfig config)
        {
            return GetSqlVendor(config.Vendor).GetDbInterfaceProviders(config);
        }
    }

    public interface ISqlVendorService
    {
        string DisambiguateSqlIdentifier(string sqlIdentifier, CodeGenConfig config);
        string BuildQualifiedName(TabularStructure tableStructure, CodeGenConfig config);
        string DetermineDotNetDataType(string sqlDataType, bool isNullable, CodeGenConfig config);
        (IDbConnection, Compiler) GetDbInterfaceProviders(CodeGenConfig config);
    }


}
