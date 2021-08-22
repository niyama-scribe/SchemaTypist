using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.Core.DatabaseMetadata
{
    public interface IAliasable
    {
        string QualifiedName__ { get; }
        string Alias__ { get; }
        string Declaration__ { get; }
        string Usage__ { get; }
    }

    static class AliasableDefaults
    {
        public static string Declare(IAliasable a) => !string.IsNullOrEmpty(a.Alias__) ? $"{a.QualifiedName__} as {a.Alias__}" : a.QualifiedName__;
        public static string Use(IAliasable a) => !string.IsNullOrEmpty(a.Alias__) ? a.Alias__ : a.QualifiedName__;
    }
}
