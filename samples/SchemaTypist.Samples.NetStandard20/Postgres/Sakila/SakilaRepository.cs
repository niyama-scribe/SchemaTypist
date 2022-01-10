using System.Data;

namespace SchemaTypist.Samples.NetStandard20.Postgres.Sakila
{
    public abstract class SakilaRepository : PostgresRepository
    {
        protected SakilaRepository(string connectionString, int timeout = 30) : base(connectionString, timeout)
        {
        }

        protected SakilaRepository(IDbConnection dbConnection, int timeout = 30) : base(dbConnection, timeout)
        {
        }
    }
}
