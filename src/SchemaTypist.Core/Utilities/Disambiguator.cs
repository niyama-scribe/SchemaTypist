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
        
        /// <summary>
        /// Simple algorithm that appends a numeral at the end of the name until it is unique.
        /// </summary>
        /// <param name="proposedName">Input object identifier</param>
        /// <returns></returns>
        public static string DisambiguateIdentifier(string proposedName, Func<string, bool> conflictFinder = null, 
            HashSet<string> usedNames = null)
        {
            if (string.IsNullOrWhiteSpace(proposedName)) return proposedName;
            
            var numeral = 0;
            var retVal = proposedName;
            while ((conflictFinder != null && conflictFinder(retVal)) || (usedNames!=null && usedNames.Contains(retVal)))
                retVal = retVal + numeral++;
            usedNames?.Add(retVal);
            return retVal;
        }
    }
}
