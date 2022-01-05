using System;
using System.Data;
using Npgsql;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace SchemaTypist.Samples.PostgreSql.Sakila;

internal class RepositoryConnector
{
    internal static RepositoryConnector PostgreSql = new RepositoryConnector(
        (str, timeout) => new QueryFactory(new NpgsqlConnection(str), new PostgresCompiler(), timeout),
        (dbConnection, timeout) => new QueryFactory(dbConnection, new PostgresCompiler(), timeout));

    public Func<string, int, QueryFactory> UseConnectionString { get; }
    public Func<IDbConnection, int, QueryFactory> UseDbConnection { get; }

    private RepositoryConnector(Func<string, int, QueryFactory> useConnectionString,
        Func<IDbConnection, int, QueryFactory> useDbConnection)
    {
        UseConnectionString = useConnectionString;
        UseDbConnection = useDbConnection;
    }


}