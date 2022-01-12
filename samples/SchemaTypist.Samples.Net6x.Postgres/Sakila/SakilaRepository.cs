using System.Data;
using SchemaTypist.Samples.Net6x.Postgres.Sakila.Generated.Persistence;

namespace SchemaTypist.Samples.Net6x.Postgres.Sakila
{
    public abstract class SakilaRepository : PostgresRepository
    {
        static SakilaRepository()
        {
            DapperTypeMapping.Init();
        }
        protected SakilaRepository(string connectionString, int timeout = 30) : base(connectionString, timeout)
        {
        }

        protected SakilaRepository(IDbConnection dbConnection, int timeout = 30) : base(dbConnection, timeout)
        {
        }
    }
}
