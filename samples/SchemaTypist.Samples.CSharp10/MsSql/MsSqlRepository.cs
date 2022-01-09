using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence;

namespace SchemaTypist.Samples.CSharp10.MsSql
{
    public abstract class MsSqlRepository : BaseRepository
    {
        private static readonly RepositoryConnector RepositoryType = RepositoryConnector.MsSql;

        protected MsSqlRepository(string connectionString, int timeout = 30) : base(RepositoryType, connectionString, timeout)
        {
        }

        protected MsSqlRepository(IDbConnection dbConnection, int timeout = 30) : base(RepositoryType, dbConnection, timeout)
        {
        }
    }
}
