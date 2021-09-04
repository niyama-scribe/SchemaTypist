using Dapper;
using SchemaTypist.Core.Schemata.Dto;

namespace SchemaTypist.Core.Schemata.Mapping
{
    static class DapperTypeMapping
    {
        public static void Init()
        {
            SqlMapper.SetTypeMap(typeof(ColumnsDto), InformationSchema.Columns.QueryResultsMapper.GetMapper());
        }
    }
}
