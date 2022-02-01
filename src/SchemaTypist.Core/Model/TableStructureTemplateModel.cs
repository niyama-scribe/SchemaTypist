using System;
using System.Collections.Generic;
using System.Text;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.Model
{
    internal abstract class TableStructureTemplateModel
    {
        public CodeGenConfig Config { get; set; }
        public TabularStructure TabularStructure { get; set; }
        public PathNamespaceStructure PathNamespace { get; set; }
    }
}
