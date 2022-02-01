using System;
using System.Collections.Generic;
using System.Text;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.Model
{
    internal abstract class TableStructureTemplateModel : TemplateModel
    {
        public TabularStructure TabularStructure { get; set; }
    }
}
