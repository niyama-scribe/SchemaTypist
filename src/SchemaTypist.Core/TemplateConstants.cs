using System;
using System.Collections.Generic;
using System.Text;

namespace SchemaTypist.Core
{
    internal static class TemplateConstants
    {
        public const string TemplateFileExtension = "sbntxt";
        public const string EntitiesTemplateFilePrefix = "Entities";
        public const string MappingTemplateFilePrefix = "Mapping";
        public const string DapperMappingTemplateFilePrefix = "DapperTypeMapping";


        public static readonly string EntitiesTemplateFile = $"{EntitiesTemplateFilePrefix}.{TemplateFileExtension}";
        public static readonly string MappingTemplateFile = $"{MappingTemplateFilePrefix}.{TemplateFileExtension}";

        public static readonly string DapperMappingTemplateFile =
            $"{DapperMappingTemplateFilePrefix}.{TemplateFileExtension}";

    }
}
