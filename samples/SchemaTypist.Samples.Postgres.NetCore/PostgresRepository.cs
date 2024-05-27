using System.Data;

namespace SchemaTypist.Samples.Postgres.NetCore;

public abstract class PostgresRepository : BaseRepository
{
    private static readonly RepositoryConnector RepositoryType = RepositoryConnector.PostgreSql;

    protected PostgresRepository(string connectionString, int timeout = 30) : base(RepositoryType, connectionString, timeout)
    {
    }

    protected PostgresRepository(IDbConnection dbConnection, int timeout = 30) : base(RepositoryType, dbConnection, timeout)
    {
    }
}