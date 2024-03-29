﻿using System;
using System.Collections.Generic;
using System.Text;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.Model
{
    internal abstract class TemplateModel
    {
        public CodeGenConfig Config { get; set; }
        public PathNamespaceStructure PathNamespace { get; set; }
    }
}
