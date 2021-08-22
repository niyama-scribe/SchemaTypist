using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchemaTypist.Schemata.Dto;

namespace SchemaTypist.Schemata.Mapping
{
    static class DapperTypeMapping
    {
        public static void Init()
        {
            SqlMapper.SetTypeMap(typeof(ColumnsDto), InformationSchema.Columns.QueryResultsMapper.GetMapper());
        }
    }
}
