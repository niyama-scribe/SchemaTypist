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
        private readonly IPluginLoader _pluginLoader;
        private readonly IDictionary<SqlVendorType, ISqlVendor> _registeredVendors =
            new Dictionary<SqlVendorType, ISqlVendor>();

        public SqlVendorService(IPluginLoader pluginLoader)
        {
            _pluginLoader = pluginLoader;
            LoadRegisteredVendors();
        }



        private void LoadRegisteredVendors()
        {
            //Load known sql dialects.
            var plugins = _pluginLoader.FindPlugins<ISqlVendor>("SchemaTypist.SqlVendors",
                typeof(SqlVendorDefinition));
            foreach (var plugin in plugins)
            {
                _registeredVendors.Add(plugin.VendorType, plugin);
            }
        }

        private ISqlVendor GetSqlVendor(SqlVendorType vendorType)
        {
            if (_registeredVendors.Count <= 0) throw new InvalidOperationException("This really should not happen");
            return _registeredVendors.Count == 1 ? _registeredVendors.Values.First() : _registeredVendors[vendorType];
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
            var sqlDialect = GetSqlVendor(config.Vendor);
            return sqlDialect.GetDbInterfaceProviders(config);
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
