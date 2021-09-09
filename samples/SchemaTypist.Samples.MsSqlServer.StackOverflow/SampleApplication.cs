using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SchemaTypist.DatabaseMetadata;
using SchemaTypist.Generated.Domain;
using SchemaTypist.Generated.Persistence.Mapping;
using SchemaTypist.SqlKata;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace SchemaTypist.Samples.MsSqlServer.StackOverflow
{
    public class SampleApplication
    {
        public static async Task Main(string[] args)
        {
            DapperTypeMapping.Init();
            SampleRepository sr = new SampleRepository();
            var posts = await sr.GetPostsByUser("Jeff Atwood");
            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Id}: {post.Title}:  {post.Body}");
            }
        }
    }

    public class SampleRepository
    {
        public async Task<IEnumerable<Post>> GetPostsByUser(string userName)
        {
            var p = Dbo.PostMapper.Table.As("c");
            var u = Dbo.User0Mapper.Table.As("tc");
    
            var q = new Query()
                .Select(p.Body, p.Id, p.LastActivityDate, p.Title)
                .From(p)
                .LeftJoin(u, j => j.On(p.OwnerUserId, u.Id))
                .Where(u.DisplayName, Op.EQ, userName)
                .Limit(1);
    
            var connection = new SqlConnection(@"server=localhost;user id=sa;password= N3v3r!nPr0d;initial catalog=StackOverflow");
            var compiler = new SqlServerCompiler();
            var db = new QueryFactory(connection, compiler);
            var posts = await db.GetAsync<Post>(q);
            return posts;
    
        }
    }
}
