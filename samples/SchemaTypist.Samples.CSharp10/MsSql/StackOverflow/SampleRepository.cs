using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchemaTypist.DatabaseMetadata;
using SchemaTypist.SqlKata;
using SchemaTypistSamples.MsSql.StackOverflow.Generated.Domain.Dbo;
using SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence.Dbo;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace SchemaTypist.Samples.CSharp10.MsSql.StackOverflow
{
    public class SampleRepository : StackOverflowRepository
    {
        public SampleRepository(string connectionString, int timeout = 30) : base(connectionString, timeout)
        {
        }

        public SampleRepository(IDbConnection dbConnection, int timeout = 30) : base(dbConnection, timeout)
        {
        }

        public async Task<IEnumerable<Post>> GetPostsByUser(string userName)
        {
            var p = PostDao.Table.As("c");
            var u = UserDao.Table.As("tc");

            var q = new Query()
                .Select(p.Body, p.Id, p.LastActivityDate, p.Title)
                .From(p)
                .LeftJoin(u, j => j.On(p.OwnerUserId, u.Id))
                .Where(u.DisplayName, Op.EQ, userName)
                .Limit(1);

            var posts = await Database.GetAsync<Post>(q);
            return posts;

        }

        
    }
}
