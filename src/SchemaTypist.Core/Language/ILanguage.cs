using System.Collections.Generic;
using System.Linq;

namespace SchemaTypist.Core.Language
{
    public interface ILanguage
    {
        IEnumerable<string> Keywords { get; }

        IEnumerable<string> DataTypes { get; }
        bool HasConflict(string proposedName);

    }
}