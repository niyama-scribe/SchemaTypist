using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchemaTypist.Samples.NetStandard20.MsSql.StackOverflow;

namespace SchemaTypist.Samples.NetFramework.MsSqlServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var sr = new SampleRepository(@"server=localhost;user id=sa;password= N3v3r!nPr0d;initial catalog=StackOverflow");
            var posts = await sr.GetPostsByUser("Jeff Atwood");
            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Id}: {post.Title}:  {post.Body}");
            }

            Console.ReadLine();
        }
    }
}
