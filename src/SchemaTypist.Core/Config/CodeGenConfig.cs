using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace SchemaTypist.Core.Config
{
    /// <summary>
    /// This is the core model for config passed into the generator.
    /// All settings must be represented here.
    /// </summary>
    public class CodeGenConfig
    {
        private static string _currDir;
        static CodeGenConfig()
        {
            _currDir = Directory.GetCurrentDirectory();
        }
        public string ConnectionString { get; set; }
        public SqlVendorType Vendor { get; set; } = SqlVendorType.MicrosoftSqlServer;

        //https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.languageversion?view=roslyn-dotnet-4.0.1
        //https://docs.microsoft.com/en-us/dotnet/standard/frameworks
        //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version
        //CSharp7_3 (net462, net47, net471, net472, net48, net481, netstandard1.x, netstandard2.0) or default (CSharp10 and above)
        public string TargetLanguageVersion { get; set; } = "Default";
        public string RootOutputDirectory { get; set; } = _currDir;
        public string RootNamespace { get; set; } = "SchemaTypist.Generated"; //Should never be empty.
        public string OutputFileNameSuffix { get; set; } = "g";
        public bool GenerateEntitiesOnly { get; set; } = false;
        public string EntitiesOutputDirectory { get; set; } = "Domain";
        public string EntitiesCustomNamespace { get; set; }
        public string EntityNameSuffix { get; set; } = "";
        public bool GeneratePersistenceOnly { get; set; } = false;
        public string PersistenceOutputDirectory { get; set; } = "Persistence";
        public string PersistenceCustomNamespace { get; set; }
        public string MapperNameSuffix { get; set; } = "Dao";
        public string NamingConflictResolutionSuffix { get; set; } = "0";
        
        public string Include { get; set; }
        public string Exclude { get; set; }

        public bool CreateImmutableEntities { get; set; } = false;

        public bool CreateRecordEntities { get; set; } = false;
        public bool UseNullableRefTypes { get; set; } = false;

        public string StripPrefix { get; set; }

        public string StripSuffix { get; set; }

    }

    public enum SqlVendorType
    {
        PostgreSql = 1,
        MicrosoftSqlServer = 2
    }
}
