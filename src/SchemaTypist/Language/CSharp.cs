using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.Language
{
    static class CSharp
    {
        private static readonly IList<string> _keywords = new List<string>();
        public static IEnumerable<string> Keywords => _keywords;
    }
}
