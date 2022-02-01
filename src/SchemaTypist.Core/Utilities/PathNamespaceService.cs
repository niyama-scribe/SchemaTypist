using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;

namespace SchemaTypist.Core.Utilities
{
    internal class PathNamespaceService : IPathNamespaceService
    {
        private readonly IFileSystemWrapper _fileSystem;
        
        public PathNamespaceService(IFileSystemWrapper fileSystem)
        {
            _fileSystem = fileSystem;
        }
        public PathNamespaceStructure Resolve(CodeGenConfig config, TabularStructure tab)
        {
            var entitiesNsStringBuilder = new StringBuilder(config.RootNamespace);
            var persistenceNsStringBuilder = new StringBuilder(config.RootNamespace);
            var entitiesFilePathParams = new List<string>();
            var persistenceFilePathParams = new List<string>();

            entitiesFilePathParams.Add(_fileSystem.CurrentDirectory);
            persistenceFilePathParams.Add(_fileSystem.CurrentDirectory);

            if (!string.IsNullOrWhiteSpace(config.RootOutputDirectory))
            {
                var formattedRootOutputDir = FormatDirectoryAsNamespace(config.RootOutputDirectory);
                entitiesNsStringBuilder.Append($".{formattedRootOutputDir}");
                persistenceNsStringBuilder.Append($".{formattedRootOutputDir}");
                entitiesFilePathParams.Add(config.RootOutputDirectory);
                persistenceFilePathParams.Add(config.RootOutputDirectory);
            }

            //Custom output directories
            if (!string.IsNullOrWhiteSpace(config.EntitiesOutputDirectory))
            {
                entitiesNsStringBuilder.Append($".{FormatDirectoryAsNamespace(config.EntitiesOutputDirectory)}");
                entitiesFilePathParams.Add(config.EntitiesOutputDirectory);
            }
            if (!string.IsNullOrWhiteSpace(config.PersistenceOutputDirectory))
            {
                persistenceNsStringBuilder.Append($".{FormatDirectoryAsNamespace(config.PersistenceOutputDirectory)}");
                persistenceFilePathParams.Add(config.PersistenceOutputDirectory);
            }

            //Custom namespaces
            if (!string.IsNullOrWhiteSpace(config.EntitiesCustomNamespace))
                entitiesNsStringBuilder.Append($".{config.EntitiesCustomNamespace}");
            if (!string.IsNullOrWhiteSpace(config.PersistenceCustomNamespace))
                persistenceNsStringBuilder.Append($".{config.PersistenceCustomNamespace}");

            //Finally
            entitiesNsStringBuilder.Append($".{tab.Schema}");
            persistenceNsStringBuilder.Append($".{tab.Schema}");
            
            entitiesFilePathParams.Add(tab.Schema);
            entitiesFilePathParams.Add($"{tab.Name}{config.EntityNameSuffix}.{config.OutputFileNameSuffix}.cs");
            persistenceFilePathParams.Add(tab.Schema);
            persistenceFilePathParams.Add($"{tab.Name}{config.MapperNameSuffix}.{config.OutputFileNameSuffix}.cs");
            
            var pns = new PathNamespaceStructure()
            {
                EntitiesNamespace = entitiesNsStringBuilder.ToString(),
                EntitiesFilePath = _fileSystem.Combine(entitiesFilePathParams.ToArray()),
                PersistenceNamespace = persistenceNsStringBuilder.ToString(),   
                PersistenceFilePath = _fileSystem.Combine(persistenceFilePathParams.ToArray())
            };
            return pns;
        }

        public void Prep(PathNamespaceStructure pathNamespace)
        {
            _fileSystem.EnsureDirectoryExists(pathNamespace.EntitiesFilePath);
            _fileSystem.EnsureDirectoryExists(pathNamespace.PersistenceFilePath);
        }

        private string FormatDirectoryAsNamespace(string directoryPath)
        {
            return directoryPath?
                .Replace(_fileSystem.DirectorySeparatorChar, '.')
                .Replace(_fileSystem.AltDirectorySeparatorChar, '.');
        }
    }

    internal interface IPathNamespaceService
    {
        PathNamespaceStructure Resolve(CodeGenConfig config, TabularStructure tab);
        void Prep(PathNamespaceStructure pathNamespace);
    }
}
