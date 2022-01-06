using System;
using System.Collections.Generic;
using System.Text;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.SqlVendors
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    internal class SqlVendorDefinition : Attribute
    {
        public SqlVendorDefinition()
        {
        }
    }
}
