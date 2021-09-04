using System.Collections.Generic;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.Model
{
    class DapperInitializerTemplateModel
    {
        public CodeGenConfig Config { get; set; }
        public List<TabularStructure> TabularStructures { get; set; }
    }
}
