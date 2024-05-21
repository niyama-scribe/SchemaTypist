namespace SchemaTypist.Core.Schemata.Dto
{
    public class ParametersDto
    {
        public string SpecificCatalog { get; set; }
        public string SpecificSchema { get; set; }
        public string SpecificName { get; set; }
        public int OrdinalPosition { get; set; }
        public string ParameterName { get; set; }
        public string DataType { get; set; }
        public int CharacterMaximumLength { get; set; }
        public int NumericPrecision { get; set; }
        public int NumericScale { get; set; }
        public bool IsNullable { get; set; }
        public string Default { get; set; }
        public string ParameterMode { get; set; }
    }
}