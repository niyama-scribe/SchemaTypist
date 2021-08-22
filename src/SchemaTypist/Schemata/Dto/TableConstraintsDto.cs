using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.Schemata.Dto
{
    public partial class TableConstraintsDto
    {
        public string ConstraintCatalog { get; set; }
        public string ConstraintSchema { get; set; }
        public string TableName { get; set; }
        public string ConstraintType { get; set; }
    }
}
