#!/bin/sh

mkdir -p .nuget-local-feed
mkdir -p .nuget-local-feed/SchemaTypist
mkdir -p .nuget-local-feed/SchemaTypist.Cli
mkdir -p .nuget-local-feed/SchemaTypist.MSBuild

dotnet restore SchemaTypist.sln
dotnet build SchemaTypist.sln -c Release
dotnet pack src/SchemaTypist/SchemaTypist.csproj
dotnet pack src/SchemaTypist.Cli/SchemaTypist.Cli.csproj
dotnet pack src/SchemaTypist.MSBuild/SchemaTypist.MSBuild.csproj
dotnet nuget push src/SchemaTypist/nupkg/SchemaTypist.0.1.0.nupkg -s $PWD/.nuget-local-feed/SchemaTypist
dotnet nuget push src/SchemaTypist.Cli/nupkg/SchemaTypist.Cli.0.1.0.nupkg -s $PWD/.nuget-local-feed/SchemaTypist.Cli

dotnet tool restore --add-source $PWD/.nuget-local-feed/SchemaTypist.Cli

