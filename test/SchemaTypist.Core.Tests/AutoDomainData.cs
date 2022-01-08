using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
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
}
