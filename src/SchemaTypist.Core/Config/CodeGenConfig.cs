using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

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
        
        //public string TargetLanguageVersion { get; set; } = "CSharp10";
        //https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.languageversion?view=roslyn-dotnet-4.0.1

        public string OutputDirectory { get; set; } = _currDir;
        public string OutputFileNameSuffix { get; set; } = "g";
        public bool GenerateEntitiesOnly { get; set; } = false;
        public string EntitiesNamespace { get; set; } = "Domain";
        public string EntityNameSuffix { get; set; } = "";
        public bool GeneratePersistenceOnly { get; set; } = false;
        public string PersistenceNamespace { get; set; } = "Persistence";
        public string MapperNameSuffix { get; set; } = "Dao";
        public string RootNamespace { get; set; } = "SchemaTypist.Generated";
        public string NamingConflictResolutionSuffix { get; set; } = "0";
        
        public string Include { get; set; }
        public string Exclude { get; set; }

        public bool CreateImmutableEntities { get; set; } = false;

        public bool CreateRecordEntities { get; set; } = false;


    }

    public enum SqlVendorType
    {
        PostgreSql = 1,
        MicrosoftSqlServer = 2
    }
}
