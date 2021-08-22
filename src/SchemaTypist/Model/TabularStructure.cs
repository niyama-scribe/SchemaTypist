using SchemaTypist.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.Model
{
    public class TabularStructure
    {
        public CodeGenConfig Config { get; set; }
        public string SqlCatalog { get; set; }
        public string SqlSchema { get; set; }
        public string SqlName { get; set; }
        public string Catalog { get; set; }
        public string Schema { get; set; }
        public string Name { get; set; }
        public TabularType TabularStructureType { get; set; } = TabularType.Table;
        public List<ColumnMetadata> Columns { get; set; } = new List<ColumnMetadata>();
    }

    public enum TabularType
    {
        Table = 1,
        View = 2
    }

    public class ColumnMetadata
    {
        public string SqlName { get; set; }
        public string SqlDataType { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public int CharacterMaximumLength { get; set; }
        public int NumericPrecision { get; set; }
        public int NumericScale { get; set; }
        public bool IsNullable { get; set; }
    }
}
