using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SchemaTypist.Core.Utilities
{
    internal class FileSystemWrapper : IFileSystemWrapper
    {
        private HashSet<string> _directories = new HashSet<string>();
        public void EnsureDirectoryExists(params string[] paths)
        {
            var directoryName = Combine(paths);
            EnsureDirectoryExists(directoryName);
        }

        private void EnsureDirectoryExists(string directoryName)
        {
            if (!_directories.Contains(directoryName))
            {
                if (!Directory.Exists(directoryName)) Directory.CreateDirectory(directoryName);
                _directories.Add(directoryName);
            }
        }

        public string Combine(params string[] paths)
        {
            return Path.Combine(paths);
        }

        public void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }

    internal interface IFileSystemWrapper
    {
        void EnsureDirectoryExists(params string[] paths);
        string Combine(params string [] paths);

        void WriteAllText(string path, string contents);
    }
}
