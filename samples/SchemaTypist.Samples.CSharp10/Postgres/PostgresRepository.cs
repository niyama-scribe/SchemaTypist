using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.Samples.CSharp10.Postgres
{
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
}
