using System.Data;
using SchemaTypist.Samples.NetStandard20.StackOverflow.Generated.Persistence;

namespace SchemaTypist.Samples.NetStandard20.MsSql.StackOverflow
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
