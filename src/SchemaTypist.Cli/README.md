### Steps to install SchemaTypist as a dotnet cli local tool

Sometimes you just have to build the cli tool and test locally (hard to believe, I know!).  Here are the steps to do this:

``` commandline
dotnet pack src/SchemaTypist.Cli/SchemaTypist.Cli.csproj
dotnet new tool-manifest
dotnet tool install --add-source src/SchemaTypist.Cli/nupkg SchemaTypist.Cli
```
