using System.Data;
using SchemaTypist.Generated.Persistence;
using SqlKata.Execution;

namespace SchemaTypist.Samples.PostgreSql.Sakila;

public abstract class BaseRepository
{
    static BaseRepository()
    {
        DapperTypeMapping.Init();
    }
    private static readonly RepositoryConnector RepositoryType = RepositoryConnector.PostgreSql;
    protected QueryFactory Database { get; }

    protected BaseRepository(string connectionString, int timeout=30) => Database = RepositoryType.UseConnectionString(connectionString, timeout);
    protected BaseRepository(IDbConnection dbConnection, int timeout=30) => Database = RepositoryType.UseDbConnection(dbConnection, timeout);

    public virtual IDbConnection Connection => Database.Connection;

}