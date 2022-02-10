using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using SchemaTypist.Core.Utilities;
using SqlKata.Compilers;

namespace SchemaTypist.Core.Tests
{
    class Fakes
    {
    }

    internal class FakesCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register<Compiler>(() => new FakeCompiler());
            fixture.Register<IFileSystemWrapper>(() => new FakeFileSystemWrapper());
        }
    }

    internal class FakeCompiler : Compiler
    {
        public FakeCompiler()
        {
        }
    }

    internal class FakeFileSystemWrapper : IFileSystemWrapper
    {
        public char DirectorySeparatorChar => '\\';
        public char AltDirectorySeparatorChar => '/';
        public string CurrentDirectory => "CurrDir";
        public void EnsureDirectoryExists(params string[] paths)
        {
            //Do nothing
        }

        public string Combine(params string[] paths)
        {
            return string.Join(AltDirectorySeparatorChar, paths);
        }

        public void WriteAllText(string path, string contents)
        {
            //Do nothing
        }
    }
}
