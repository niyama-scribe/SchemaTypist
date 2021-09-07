using System.IO;

namespace SchemaTypist.Core.Config
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
        public string TargetFramework { get; set; } = "netstandard2.0";
        public string TargetLanguage { get; set; } = "CSharp";
        public string TargetLanguageVersion { get; set; } = "9.0";

        public string OutputDirectory { get; set; } = _currDir;
        public string OutputFileNameSuffix { get; set; } = "g";
        public bool GenerateEntitiesOnly { get; set; } = false;
        public string EntitiesNamespace { get; set; } = "Domain";
        public string EntityNameSuffix { get; set; } = "";
        public bool GeneratePersistenceOnly { get; set; } = false;
        public string PersistenceNamespace { get; set; } = "Persistence";
        public string MappingNamespace { get; set; } = "Mapping";
        public string MapperNameSuffix { get; set; } = "Mapper";
        public string RootNamespace { get; set; } = "SchemaTypist.Generated";
        public string Include { get; set; }
        public string Exclude { get; set; }

    }

    public enum SqlVendorType
    {
        PostgreSql = 1,
        MicrosoftSqlServer = 2
    }
}
