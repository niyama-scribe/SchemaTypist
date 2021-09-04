namespace SchemaTypist.Core.Schemata.Dto
{
    public partial class TableConstraintsDto
    {
        public string ConstraintCatalog { get; set; }
        public string ConstraintSchema { get; set; }
        public string TableName { get; set; }
        public string ConstraintType { get; set; }
    }
}
