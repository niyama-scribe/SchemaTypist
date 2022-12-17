using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.Templating
{
    internal static class TemplateConstants
    {
        public const string TemplateFileExtension = "sbntxt";
        public const string EntitiesTemplateFilePrefix = "Entities";
        public const string PersistenceTemplateFilePrefix = "Persistence";
        public const string DapperInitialiserTemplateFilePrefix = "DapperInitialiser";


        private static readonly string EntitiesTemplateFile = $"{EntitiesTemplateFilePrefix}.{TemplateFileExtension}";
        private static readonly string PersistenceTemplateFile = $"{PersistenceTemplateFilePrefix}.{TemplateFileExtension}";

        private static readonly string DapperInitialiserTemplateFile =
            $"{DapperInitialiserTemplateFilePrefix}.{TemplateFileExtension}";

        public static (string, string, string) GetTemplateFileNames(CodeGenConfig config)
        {
            return ($"{config.TargetLanguageVersion}.{EntitiesTemplateFile}",
                $"{config.TargetLanguageVersion}.{PersistenceTemplateFile}",
                $"{config.TargetLanguageVersion}.{DapperInitialiserTemplateFile}");
        }

    }
}
