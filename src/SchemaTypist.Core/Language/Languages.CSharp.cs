using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.Language
{
    internal static partial class Languages
    {
        internal static class CSharp
        {
            public static ILanguage Language { get; } = new LanguageDetails();
            private class LanguageDetails : ILanguage
            {
                public IEnumerable<string> Keywords { get; } = new List<string>()
            {
                "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
                "class", "const", "continue", "decimal", "default", "delegate", "do", "double",
                "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float",
                "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is",
                "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override",
                "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed",
                "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw",
                "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual",
                "void", "volatile", "while",
                "add", "and", "alias", "ascending", "async", "await", "by", "descending", "dynamic", "equals",
                "from", "get", "global", "group", "init", "into", "join", "let", "managed", "nameof", "nint",
                "not", "notnull", "nuint", "on", "or", "orderby", "partial", "record", "remove", "select",
                "set", "unmanaged", "value", "var", "when", "where", "where", "with", "yield"
            };

                public IEnumerable<string> DataTypes { get; } = new List<string>()
            {
                "bool", "byte", "sbyte", "char", "decimal", "double", "float", "int", "uint",
                "nint", "nuint", "long", "ulong", "short", "ushort", "object", "string", "dynamic",
                "System.Boolean", "System.Byte", "System.SByte", "System.Char", "System.Decimal",
                "System.Double", "System.Single", "System.Int32", "System.UInt32", "System.IntPtr",
                "System.UIntPtr", "System.Int64", "System.UInt64", "System.Int16", "System.UInt16",
                "System.Object", "System.String", "Boolean", "Byte", "SByte", "Char", "Decimal",
                "Double", "Single", "Int32", "UInt32", "IntPtr", "UIntPtr", "Int64", "UInt64",
                "Int16", "UInt16", "Object", "String"
            };

                public bool HasConflict(string proposedName)
                {
                    return Keywords.Contains(proposedName) || DataTypes.Contains(proposedName);
                }

            }

            public static string HandleNullability(string typeName, CodeGenConfig config)
            {
                if (string.IsNullOrWhiteSpace(typeName) || config == null || typeName.EndsWith("?")) return typeName;
                if (!config.UseNullableRefTypes ) return typeName;
                var type = GetTypeWithMatchingName(typeName);
                return type is {IsValueType: false}
                    ? $"{typeName}?"
                    : typeName;
            }

            private static Type GetTypeWithMatchingName(string typeName)
            {
                //Best effort to try and find the actual runtime type given the typeName.
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    try
                    {
                        foreach (var type in assembly.GetTypes())
                        {
                            if (type.Name.Equals(typeName, StringComparison.OrdinalIgnoreCase))
                            {
                                return type;
                            }
                        }
                    }
                    catch (ReflectionTypeLoadException)
                    {
                        continue;
                    }
                }

                return null;
            }

        }
    }
}
