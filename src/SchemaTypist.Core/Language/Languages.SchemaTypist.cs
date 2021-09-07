using System.Collections.Generic;
using System.Linq;

namespace SchemaTypist.Core.Language
{
    internal static partial class Languages
    {
        //TODO: Have to avoid conflict with SchemaTypist keywords
        public static ILanguage SchemaTypist { get; } = new SchemaTypistLanguage();
        private class SchemaTypistLanguage : ILanguage
        {
            public IEnumerable<string> Keywords { get; } = Enumerable.Empty<string>();
            public IEnumerable<string> DataTypes { get; } = Enumerable.Empty<string>();

            public bool HasConflict(string proposedName)
            {
                return Keywords.Contains(proposedName) || DataTypes.Contains(proposedName);
        }
        }
    }

}
