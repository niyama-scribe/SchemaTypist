using System.Data;
using SchemaTypist.Samples.Postgres.NetCore;
using SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence;

namespace SchemaTypist.Samples.Postgres.NetCore.Sakila;

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