using System.Data;
using Npgsql;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace SchemaTypist.Samples.Postgres.NetFramework
{
    public abstract class PostgresRepository
    {
        protected PostgresRepository(string connectionString, int timeout = 30)
        {
            Database = new QueryFactory(new NpgsqlConnection(connectionString), new PostgresCompiler(), timeout);
        }

        protected PostgresRepository(IDbConnection connection, int timeout = 30)
        {
            Database = new QueryFactory(connection, new PostgresCompiler(), timeout);
        }

        protected QueryFactory Database { get; }

        public IDbConnection Connection => Database.Connection;
    }
}