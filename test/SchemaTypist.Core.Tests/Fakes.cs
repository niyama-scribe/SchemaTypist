using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Kernel;
using SchemaTypist.Core.Utilities;
using Auzaar.AutoFixture;
using SqlKata.Compilers;

namespace SchemaTypist.Core.Tests
{
    internal class FakesCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register<Compiler>(() => new FakeCompiler());
            //fixture.Register<IFileSystemWrapper>(() => new FakeFileSystemWrapper());
            //fixture.Customizations.Add(new CompilerSpecimenBuilder());
            //fixture.Customizations.Add(new FileSystemWrapperSpecimenBuilder());
        }
    }

    internal class CompilerSpecimenBuilder : CustomTypeSpecimenBuilderBase<Compiler>
    {
        protected override Compiler? BuildSpecimen() => new FakeCompiler();
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

    internal class FileSystemWrapperSpecimenBuilder : CustomTypeSpecimenBuilderBase<IFileSystemWrapper>
    {
        protected override IFileSystemWrapper? BuildSpecimen() => new FakeFileSystemWrapper();

    }


}
