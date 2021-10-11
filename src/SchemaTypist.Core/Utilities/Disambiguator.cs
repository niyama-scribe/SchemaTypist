using System;
using System.Collections.Generic;
using System.Text;

namespace SchemaTypist.Core.Utilities
{
    /// <summary>
    /// The purpose of this class is to disambiguate identifiers during conversion from sql objects to dotnet.
    /// </summary>
    internal static class Disambiguator
    {
        private static HashSet<string> _usedNames = new HashSet<string>();

        /// <summary>
        /// Simple algorithm that appends a numeral at the end of the name until it is unique.
        /// </summary>
        /// <param name="proposedName">Input object identifier</param>
        /// <returns></returns>
        public static string DisambiguateIdentifier(string proposedName, Func<string, bool> conflictFinder = null)
        {
            if (string.IsNullOrWhiteSpace(proposedName)) return proposedName;
            
            var numeral = 0;
            var retVal = proposedName;
            while (_usedNames.Contains(proposedName) || (conflictFinder != null && conflictFinder(proposedName)))
                retVal = proposedName + numeral++;
            return retVal;
        }
    }
}
