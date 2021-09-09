Steps to install SchemaTypist as a dotnet cli local tool

dotnet pack src/SchemaTypist.Cli/SchemaTypist.Cli.csproj
dotnet new tool-manifest
dotnet tool install --add-source src/SchemaTypist.Cli/nupkg SchemaTypist.Cli
