using System;
using System.Threading.Tasks;
using SchemaTypist.Samples.MsSql.NetStandard20;

namespace SchemaTypist.Samples.MsSql.NetFrameworkClient
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var repository =
                new PostRepository("server=localhost;user id=sa;password= N3v3r!nPr0d;initial catalog=StackOverflow");
            var posts = await repository.GetPostsByUser("Jeff Atwood");
            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Id}: {post.Title}:  {post.Body}");
            }
        }
    }
}