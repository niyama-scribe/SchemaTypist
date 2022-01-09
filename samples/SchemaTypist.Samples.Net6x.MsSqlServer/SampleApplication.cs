// See https://aka.ms/new-console-template for more information

using SchemaTypist.Samples.CSharp10.MsSql.StackOverflow;

Console.WriteLine("Hello, World!");

var sr = new SampleRepository(@"server=localhost;user id=sa;password= N3v3r!nPr0d;initial catalog=StackOverflow");
var posts = await sr.GetPostsByUser("Jeff Atwood");
foreach (var post in posts)
{
    Console.WriteLine($"{post.Id}: {post.Title}:  {post.Body}");
}
