using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using SchemaTypist.Core.Utilities;
using SqlKata.Compilers;
using Xunit.Sdk;

namespace SchemaTypist.Core.Tests
{
    public class AutoDomainDataAttribute : AutoDataAttribute
    {
        public AutoDomainDataAttribute() 
            : base(() =>
            {
                var fixture = new Fixture().Customize(new AutoMoqCustomization());
                fixture.Register<Compiler>(() => new FakeCompiler());
                fixture.Register<IFileSystemWrapper>(() => new FakeFileSystemWrapper());
                return fixture;
            })
        {
        }
    }

    public class InlineAutoDomainDataAttribute : InlineAutoDataAttribute
    {
        public InlineAutoDomainDataAttribute(params object[] values) : base(new AutoDomainDataAttribute(), values)
        {
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
