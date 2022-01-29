using System;
using System.Collections.Generic;
using System.Text;

namespace SchemaTypist.Core
{
    internal static class TemplateConstants
    {
        public const string TemplateFileExtension = "sbntxt";
        public const string EntitiesTemplateFilePrefix = "Entities";
        public const string PersistenceTemplateFilePrefix = "Persistence";
        public const string DapperInitialiserTemplateFilePrefix = "DapperInitialiser";


        public static readonly string EntitiesTemplateFile = $"{EntitiesTemplateFilePrefix}.{TemplateFileExtension}";
        public static readonly string PersistenceTemplateFile = $"{PersistenceTemplateFilePrefix}.{TemplateFileExtension}";

        public static readonly string DapperInitialiserTemplateFile =
            $"{DapperInitialiserTemplateFilePrefix}.{TemplateFileExtension}";

    }
}
