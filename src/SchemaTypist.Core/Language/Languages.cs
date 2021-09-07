using System.Collections.Generic;
using Microsoft.CSharp.RuntimeBinder;

namespace SchemaTypist.Core.Language
{
    internal static partial class Languages
    {
        public static ILanguage GetProgrammingLanguage(string targetLanguage)
        {
            return targetLanguage switch
            {
                "CSharp" => CSharp.Language,
                _ => null
            };
        }
    }
}
