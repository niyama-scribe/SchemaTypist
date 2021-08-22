using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.Config
{
    public class CodeGenConfig
    {
        private static string _currDir;
        static CodeGenConfig()
        {
            _currDir = Directory.GetCurrentDirectory();
        }
        public string ConnectionString { get; set; }
        public SqlVendorType Vendor { get; set; } = SqlVendorType.MicrosoftSqlServer; 
        public string TargetRootDirectory { get; set; } = _currDir;
        public string TargetFileNameSuffix { get; set; } = "g";
        public string RootNamespace { get; set; } = "SchemaTypist.Generated";
        public string TargetFramework { get; set; } = "netstandard2.0";
        public string ModelNamespace { get; set; } = "Domain";
        public string MappingNamespace { get; set; } = "Persistence";
        public string ModelNameSuffix { get; set; } = "Entity";
    }

    public enum SqlVendorType
    {
        PostgreSql = 1,
        MicrosoftSqlServer = 2
    }
}
