using System.Collections.Generic;

namespace SchemaTypist.Core.Schemata.Dto
{
    public class RoutinesDto
    {
        public string SpecificCatalog { get; set; }
        public string SpecificSchema { get; set; }
        public string SpecificName { get; set; }
        public string RoutineType { get; set; }
        public string DataType { get; set; }
        public List<ParametersDto> Parameters { get; set; }
        
    }
}