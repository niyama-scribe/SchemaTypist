using System.Collections.Generic;
using SchemaTypist.Core.Schemata.Dto;

namespace SchemaTypist.Core.Schemata
{
    public class SchemataMetadata
    {
        public IList<ColumnsDto> TablesMetadata { get; set; }
        // public IEnumerable<RoutinesDto> RoutinesMetadata { get; }
        // public IEnumerable<RoutinesTableValuedParametersDto> RoutinesTableValuedParameterMetadata { get; }
        // public IEnumerable<RoutinesReturnTypesDto> RoutinesReturnTypesMetadata { get; }

    }
}