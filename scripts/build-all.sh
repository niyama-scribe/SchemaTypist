#!/bin/sh

#take one parameter 

#mkdir -p .nuget-local-feed
#mkdir -p .nuget-local-feed/SchemaTypist
#mkdir -p .nuget-local-feed/SchemaTypist.Cli
#mkdir -p .nuget-local-feed/SchemaTypist.MSBuild

version="$1"
nuget_local=${2:-/d/dev/local-artifact-repo/nuget}

dotnet restore SchemaTypist.sln
dotnet build SchemaTypist.sln -c Release
dotnet pack src/SchemaTypist/SchemaTypist.csproj
dotnet pack src/SchemaTypist.Cli/SchemaTypist.Cli.csproj
dotnet pack src/SchemaTypist.MSBuild/SchemaTypist.MSBuild.csproj
dotnet nuget push src/SchemaTypist/nupkg/SchemaTypist.${version}.nupkg -s ${nuget_local}/SchemaTypist
dotnet nuget push src/SchemaTypist.Cli/nupkg/SchemaTypist.Cli.${version}.nupkg -s ${nuget_local}/SchemaTypist.Cli
dotnet nuget push src/SchemaTypist.MSBuild/bin/Debug/SchemaTypist.MSBuild.${version}.nupkg -s ${nuget_local}/SchemaTypist.Cli

dotnet tool update schematypist.cli --add-source ${nuget_local}/SchemaTypist.Cli --version ${version}
