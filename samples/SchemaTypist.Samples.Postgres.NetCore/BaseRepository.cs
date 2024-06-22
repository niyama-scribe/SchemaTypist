using System.Data;
using SqlKata.Execution;

namespace SchemaTypist.Samples.Postgres.NetCore;

public abstract class BaseRepository 
{
    protected QueryFactory Database { get; set; }

    protected BaseRepository(RepositoryConnector repositoryType, string connectionString, int timeout = 30) 
        => Database = repositoryType.UseConnectionString(connectionString, timeout);

    protected BaseRepository(RepositoryConnector repositoryType, IDbConnection dbConnection, int timeout = 30)
        => Database = repositoryType.UseDbConnection(dbConnection, timeout);

    public virtual IDbConnection Connection => Database.Connection;

}