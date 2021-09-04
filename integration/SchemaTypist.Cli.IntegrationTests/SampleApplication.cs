using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SchemaTypist.DatabaseMetadata;
using SchemaTypist.Generated.Domain;
using SchemaTypist.Generated.Persistence;
using SchemaTypist.SqlKata;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using static SchemaTypist.Generated.Persistence.Dbo;

namespace SchemaTypist.Cli.IntegrationTests
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
        public async Task<IEnumerable<PostEntity>> GetPostsByUser(string userName)
        {
            var p = Post.Table.As("c");
            var u = User.Table.As("tc");

            var q = new Query()
                .Select(p.Body, p.Id, p.LastActivityDate, p.Title)
                .From(p)
                .LeftJoin(u, j => j.On(p.OwnerUserId, u.Id))
                .Where(u.DisplayName, Op.EQ, userName)
                .Limit(1);

            var connection = new SqlConnection(@"server=localhost;user id=sa;password= N3v3r!nPr0d;initial catalog=StackOverflow");
            var compiler = new SqlServerCompiler();
            var db = new QueryFactory(connection, compiler);
            var posts = await db.GetAsync<PostEntity>(q);
            return posts;

        }
}
}
