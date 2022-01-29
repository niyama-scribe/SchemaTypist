using System.Collections.Generic;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.Model
{
    internal class DapperInitialiserTemplateModel
    {
        public CodeGenConfig Config { get; set; }
        public List<TabularStructure> TabularStructures { get; set; }
    }
}
