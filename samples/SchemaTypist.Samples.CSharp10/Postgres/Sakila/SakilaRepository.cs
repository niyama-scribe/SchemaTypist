using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.Samples.CSharp10.Postgres.Sakila
{
    public abstract class SakilaRepository : PostgresRepository
    {
        protected SakilaRepository(string connectionString, int timeout = 30) : base(connectionString, timeout)
        {
        }

        protected SakilaRepository(IDbConnection dbConnection, int timeout = 30) : base(dbConnection, timeout)
        {
        }
    }
}
