using System;
using System.Collections.Generic;
using System.Text;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.Model
{
    internal class EntitiesTemplateModel
    {
        public CodeGenConfig Config { get; set; }
        public TabularStructure TabularStructure { get; set; }
    }
}
