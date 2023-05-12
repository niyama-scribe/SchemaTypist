using System;
using System.Collections.Generic;
using System.Linq;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Utilities;

namespace SchemaTypist.Core.SqlVendors
{
    /// <summary>
    ///     This class provides methods to load SqlVendor plugins (basically libraries that are called
    ///     SchemaTypist.SqlVendors.*)
    ///     These libraries will contain all the RDBMS-specific customizations like sql dialects and other idiosyncrasies.
    /// </summary>
    internal class SqlVendorPluginLoader : ISqlVendorPluginLoader
    {
        private readonly IPluginLoader _pluginLoader;

        private readonly IDictionary<SqlVendorType, ISqlVendor> _registeredVendors =
            new Dictionary<SqlVendorType, ISqlVendor>();

        private volatile bool _isLoaded;

        public SqlVendorPluginLoader(IPluginLoader pluginLoader)
        {
            _pluginLoader = pluginLoader;
        }

        public void LoadRegisteredVendors()
        {
            if (_isLoaded) return;
            try
            {
                //Load known sql dialects.
                var plugins = _pluginLoader.FindPlugins<ISqlVendor>("SchemaTypist.SqlVendors",
                    typeof(SqlVendorDefinition));
                foreach (var plugin in plugins) _registeredVendors.Add(plugin.VendorType, plugin);
            }
            finally
            {
                _isLoaded = true;
            }
        }

        public ISqlVendor GetSqlVendor(SqlVendorType sqlVendorType)
        {
            if (!_isLoaded) throw new InvalidOperationException($"Please call {nameof(LoadRegisteredVendors)} first.");
            if (_registeredVendors.Count <= 0)
                throw new InvalidOperationException(
                    "We don't seem to have any SqlVendor libraries referenced which shouldn't happen.  Please reference at least one of the SqlVendor libraries.");
            return _registeredVendors.Count == 1
                ? _registeredVendors.Values.First()
                : _registeredVendors[sqlVendorType];
        }
    }

    public interface ISqlVendorPluginLoader
    {
        void LoadRegisteredVendors();
        ISqlVendor GetSqlVendor(SqlVendorType sqlVendorType);
    }
}