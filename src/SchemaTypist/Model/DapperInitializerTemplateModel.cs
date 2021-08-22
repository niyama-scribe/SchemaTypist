using SchemaTypist.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.Model
{
    class DapperInitializerTemplateModel
    {
        public CodeGenConfig Config { get; set; }
        public List<TabularStructure> TabularStructures { get; set; }
    }
}
