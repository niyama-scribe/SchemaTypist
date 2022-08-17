namespace SchemaTypist.Core.Schemata.Dto
{
    public partial class ColumnsDto
    {
        public string TableCatalog { get; set; }
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public int OrdinalPosition { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public int CharacterMaxLength { get; set; }
        public int NumericPrecision { get; set; }
        public int NumericScale { get; set; }
        public string IsNullable { get; set; }
        public string ColumnDefault { get; set; }
    }
}
