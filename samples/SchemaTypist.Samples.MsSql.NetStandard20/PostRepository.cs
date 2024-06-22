using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using SchemaTypist.DatabaseMetadata;
using SchemaTypist.Samples.MsSql.Generated.StackOverflow.Domain.Dbo;
using SchemaTypist.Samples.MsSql.Generated.StackOverflow.Persistence.Dbo;
using SchemaTypist.SqlKata;
using SqlKata;

namespace SchemaTypist.Samples.MsSql.NetStandard20
{
    public class PostRepository : MsSqlRepository
    {
        public PostRepository(string connectionString, int timeout = 30) : base(connectionString, timeout)
        {
        }

        public PostRepository(IDbConnection dbConnection, int timeout = 30) : base(dbConnection, timeout)
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