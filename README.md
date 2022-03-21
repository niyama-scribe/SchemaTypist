# SchemaTypist

SchemaTypist enables type-safe database interactions using Dapper and SqlKata, by generating C# code from database schemata.  All you need to worry about are the actual queries.  Leave the rest to SchemaTypist!

![Nuget](https://img.shields.io/nuget/v/SchemaTypist?color=blue&label=SchemaTypist&logo=Nuget&style=plastic)
![Nuget](https://img.shields.io/nuget/v/SchemaTypist.Cli?color=blue&label=SchemaTypist.Cli&logo=Nuget&style=plastic)
![Nuget](https://img.shields.io/nuget/v/SchemaTypist.MSBuild?color=blue&label=SchemaTypist.MSBuild&logo=Nuget&style=plastic)
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/niyama-scribe/SchemaTypist/Build%20&%20Test?style=plastic)


## How does it work?

At its core, SchemaTypist provides a highly configurable, dotnet CLI tool called `schematypist-cli`.  The CLI tool inspects schemata exposed by your database and generates metadata mapping as C# code, which you can then use to interact with the database.

## Where do I start?

 - Install the SchemaTypist CLI tool.
   ```commandline 
     dotnet tool install -g schematypist.cli 
   ```
 - Add the following to your csproj file.
   ```xml
     <PropertyGroup>
		<SchemaTypist_ConnectionString>%22server=localhost;user id=sa;password=N3v3r!nPr0d;Database=StackOverflow%22</SchemaTypist_ConnectionString>
	</PropertyGroup>
	
	<Target Name="MyGenerator" BeforeTargets="PrepareForBuild">
		<CallTarget Targets="SchemaTypist_DoGenerate" />
		<Message Importance="high" Text="Generated source files using SchemaTypist" />
	</Target>
	
	<ItemGroup>
	  <PackageReference Include="SchemaTypist" Version="0.6.6" />
	  <PackageReference Include="SchemaTypist.MSBuild" Version="0.6.6" />
	</ItemGroup>
   ```
 - Finally, run the build.
   ```commandline
     dotnet build -p:SchemaTypist_Generate=true 
   ```
 - You're done.  Now, go forth and query your database at runtime.
   ```csharp
     public class SampleRepository
     {
         public async Task<IEnumerable<Post>> GetPostsByUser(string userName)
         {
             var p = PostDao.Table.As("p");
             var u = UserDao.Table.As("u");
     
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
   ```

   For more examples, please look in the samples folder.

## Features
 - Can use secrets for connection string instead of storing it in plain text in your csproj file.
 - Supports the following RDBMS Providers:
   *  Microsoft Sql Server (tested).
   *  PostgreSql (tested).
   *  Potentially supports any RDBMS that is compliant with SQL-99 standard (i.e. exposes INFORMATION_SCHEMA views).
 - Generated code is compatible with:
   *  .NET Standard 2.0 (.NET Framework 4.6.1 and above) - CSharp 7.3
   *  .NET 6.0 - CSharp 10
 - Include and exclude regexes to include/exclude database objects respectively.
 - Supports immutable objects and supports records.
 - Class and property names follow database object names, but are cleansed to fit C# naming conventions:
   * Supports stripping common db object name prefixes like "tbl_", "vw_" etc. when creating classes.
   * Converts DB object names from snake_case or kebab-case_ to PascalCase.
   * Entity class names are singularized by default.
   * Customizable suffixes for entity as well as persistence classes.
 - Files, paths and namespaces:
   * Root directory and root namespace for generated code
   * Custom subdirectories  for entity as well as persistence classes
   * Custom file name suffix
 - And many more...
  

## Support
- Don't forget to give a ⭐ on [GitHub](https://github.com/niyama-scribe/SchemaTypist)
- Share your feedback and ideas to improve this tool.  Please feel free to create an issue to discuss further.