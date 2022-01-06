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
    internal static partial class SqlVendor
    {
        private static readonly IDictionary<SqlVendorType, ISqlVendor> RegisteredVendors =
            new Dictionary<SqlVendorType, ISqlVendor>();

        static SqlVendor()
        {
            //Load known sql dialects.
            var plugins = PluginLoader.FindPlugins<ISqlVendor>("SchemaTypist.SqlVendors",
                typeof(SqlVendorDefinition), false);
            foreach (var plugin in plugins)
            {
                RegisteredVendors.Add(plugin.VendorType, plugin);
            }
        }

        private static ISqlVendor GetSqlVendor(SqlVendorType vendorType)
        {
            if (RegisteredVendors.Count <= 0) throw new InvalidOperationException("This really should not happen");
            return RegisteredVendors.Count == 1 ? RegisteredVendors.Values.First() : RegisteredVendors[vendorType];
        }


        private static ISqlDialect GetSqlDialect(SqlVendorType vendorType)
        {
            return GetSqlVendor(vendorType)?.Dialect;
        }

        public static string DisambiguateSqlIdentifier(string sqlIdentifier, CodeGenConfig config)
        {
            var sqlDialect = GetSqlDialect(config.Vendor);
            return Disambiguator.DisambiguateIdentifier(sqlIdentifier, s => sqlDialect.HasConflict(s));
        }

        public static string BuildQualifiedName(TabularStructure tableStructure, CodeGenConfig config)
        {
            var sqlDialect = GetSqlDialect(config.Vendor);
            return sqlDialect.BuildQualifiedName(tableStructure);
        }

        public static string DetermineDotNetDataType(string sqlDataType, bool isNullable, CodeGenConfig config)
        {
            var sqlDialect = GetSqlDialect(config.Vendor);
            return sqlDialect.DetermineDotNetDataType(sqlDataType, isNullable);

        }

        public static (IDbConnection, Compiler) GetDbInterfaceProviders(CodeGenConfig config)
        {
            var sqlDialect = GetSqlVendor(config.Vendor);
            return sqlDialect.GetDbInterfaceProviders(config);
        }
    }
}
