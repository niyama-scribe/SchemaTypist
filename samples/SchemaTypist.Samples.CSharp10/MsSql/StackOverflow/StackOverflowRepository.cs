using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence;

namespace SchemaTypist.Samples.CSharp10.MsSql.StackOverflow
{
    public abstract class StackOverflowRepository : MsSqlRepository
    {
        static StackOverflowRepository()
        {
            DapperTypeMapping.Init();
        }

        protected StackOverflowRepository(string connectionString, int timeout = 30) : base(connectionString, timeout)
        {
        }

        protected StackOverflowRepository(IDbConnection dbConnection, int timeout = 30) : base(dbConnection, timeout)
        {
        }
    }
}
