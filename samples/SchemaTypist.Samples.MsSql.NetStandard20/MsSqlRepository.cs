using System.Data;
using System.Data.SqlClient;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace SchemaTypist.Samples.MsSql.NetStandard20
{
    public abstract class MsSqlRepository
    {
        protected MsSqlRepository(string connectionString, int timeout = 30)
        {
            Database = new QueryFactory(new SqlConnection(connectionString), new SqlServerCompiler(), timeout);
        }

        protected MsSqlRepository(IDbConnection dbConnection, int timeout = 30)
        {
            Database = new QueryFactory(dbConnection, new SqlServerCompiler(), timeout);
        }

        protected QueryFactory Database { get; }

        public IDbConnection Connection => Database.Connection;
    }
}