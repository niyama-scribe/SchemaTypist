using System;
using System.Collections.Generic;
using System.Text;

namespace SchemaTypist.Core.Model
{
    /// <summary>
    /// Contains resolved path and namespace settings for the source code to be generated.
    /// </summary>
    public class PathNamespaceStructure
    {
        public string EntitiesFilePath { get; set; }
        public string EntitiesNamespace { get; set; }
        public string PersistenceFilePath { get; set; }
        public string PersistenceNamespace { get; set; }
        public string DapperInitialiserFilePath { get; set; }
        public string DapperInitialiserNamespace { get; set; }
    }
}
