using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlKata.Execution;


namespace SchemaTypist.Samples.CSharp10
{
    public abstract class BaseRepository 
    {
        protected QueryFactory Database { get; set; }

        protected BaseRepository(RepositoryConnector repositoryType, string connectionString, int timeout = 30) 
            => Database = repositoryType.UseConnectionString(connectionString, timeout);

        protected BaseRepository(RepositoryConnector repositoryType, IDbConnection dbConnection, int timeout = 30)
            => Database = repositoryType.UseDbConnection(dbConnection, timeout);

        public virtual IDbConnection Connection => Database.Connection;

    }

    
}
