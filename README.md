# SchemaTypist

SchemaTypist enables type-safe database interactions using Dapper and SqlKata, by generating C# code from database schemata.  All you need to worry about are the actual queries.  Leave the rest to SchemaTypist!


## How does it work?

At its core, SchemaTypist provides a highly configurable, dotnet CLI tool called `schematypist-cli`.  The CLI tool inspects schemata exposed by your database and generates metadata mapping as C# code, which you can then use to interact with the database.

## Where do I start?

 - Install the SchemaTypist CLI tool.
   ```commandline 
     dotnet install -g schematypist.cli 
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
	  <PackageReference Include="SchemaTypist" Version="0.1.0" Condition="'$(Configuration)'=='Release'" />
	  <PackageReference Include="SchemaTypist.MSBuild" Version="0.1.0" />
	</ItemGroup>
   ```
 - Finally, run the build.
   ```commandline
     dotnet build -p:SchemaTypist.Generate=true 
   ```
 - You're done.  Now, go forth and query your database at runtime.
   ```csharp
     public async Task<IEnumerable<Post>> GetPostsByUser(string userName)
     {
         var p = Dbo.PostMapper.Table.As("p");
         var u = Dbo.UserMapper.Table.As("u");
    
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
   ```

   For more examples, please look in the samples folder.
