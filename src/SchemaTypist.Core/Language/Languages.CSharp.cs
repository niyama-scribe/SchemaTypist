using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.Language
{
    internal static partial class Languages
    {
        internal static class CSharp
        {
            private static Assembly _mscorLib = Assembly.GetAssembly(typeof(int));
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

            public static string HandleNullability(string typeName, bool canBeSetToNull, CodeGenConfig config)
            {
                if (string.IsNullOrWhiteSpace(typeName) || config == null) return typeName;

                if (!canBeSetToNull) return typeName; //If db column is not nullable, return mapped type.

                var isReferenceType = IsReferenceType(typeName);
                if (!isReferenceType) return typeName;  //If db column is nullable and mapped type is value type, return mapped type as we handle nullability implicitly.

                //At this point, db column is nullable and mapped type is reference type.
                //If not using nullable reference types, just return mapped type.
                //If using nullable reference type, then return it as nullable.

                return config.TargetLanguageVersion.ToLower() == "default" && config.UseNullableRefTypes 
                    ? $"{typeName}?" : 
                    typeName; 
            }

            public static bool IsNullable(string typeName) => (typeName ?? "").EndsWith("?");

            public static bool IsReferenceType(string typeName)
            {
                if (string.IsNullOrEmpty(typeName)) return false;

                var coreTypeName = typeName.Replace("?", "");
                if (coreTypeName.ToLowerInvariant() == "object") return true;
                //HACK:  checking for closing square brackets to determine if it is an array, need a better way of doing this
                if (coreTypeName.EndsWith("]")) return true;
                var type = GetTypeWithMatchingName(coreTypeName);
                return type is {IsValueType: false, IsArray:false};
            }

            private static Type GetTypeWithMatchingName(string typeName)
            {
                //Best effort to try and find the actual runtime type given the typeName.

                
                using (var provider = new CSharpCodeProvider())
                {
                    foreach (var type in _mscorLib.DefinedTypes)
                    {
                        if (string.Equals(type.Namespace, "System"))
                        {
                            var typeRef = new CodeTypeReference(type);
                            var csTypeName = provider.GetTypeOutput(typeRef);
                            if (typeName.Equals(csTypeName))
                            {
                                return type;
                            }
                        }
                    }
                }

                /*foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
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
                }*/

                return null;
            }

        }
    }
}
