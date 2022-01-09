using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace SchemaTypist.Samples.CSharp10
{
    public class RepositoryConnector
    {
        internal static RepositoryConnector PostgreSql = new RepositoryConnector(
            (str, timeout) => new QueryFactory(new NpgsqlConnection(str), new PostgresCompiler(), timeout),
            (dbConnection, timeout) => new QueryFactory(dbConnection, new PostgresCompiler(), timeout));

        internal static RepositoryConnector MsSql = new RepositoryConnector(
            (str, timeout) => new QueryFactory(new SqlConnection(str), new SqlServerCompiler(), timeout),
            (dbConnection, timeout) => new QueryFactory(dbConnection, new SqlServerCompiler(), timeout));

        public Func<string, int, QueryFactory> UseConnectionString { get; }
        public Func<IDbConnection, int, QueryFactory> UseDbConnection { get; }

        private RepositoryConnector(Func<string, int, QueryFactory> useConnectionString,
            Func<IDbConnection, int, QueryFactory> useDbConnection)
        {
            UseConnectionString = useConnectionString;
            UseDbConnection = useDbConnection;
        }


    }
}
