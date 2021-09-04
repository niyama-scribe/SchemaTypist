using System.Collections.Generic;

namespace SchemaTypist.Core.Language
{
    static class CSharp
    {
        private static readonly IList<string> _keywords = new List<string>();
        public static IEnumerable<string> Keywords => _keywords;
    }
}
