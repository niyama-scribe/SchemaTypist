using System;
using System.Security.Cryptography.X509Certificates;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using SchemaTypist.Core.Utilities;
using SqlKata.Compilers;

namespace SchemaTypist.Core.Tests.Autofixture
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AutoDomainDataAttribute : AutoDataAttribute
    {
        public AutoDomainDataAttribute() 
            : base(() =>
            {
                var fixture = new Fixture()
                    .Customize(FixtureCustomizationsRegistrar.Default.Compose());
                return fixture;
            })
        {
        }

        public AutoDomainDataAttribute(params string[] fixtureCustomizationKeys)
        :base(() =>
        {
            var fixture = new Fixture()
                ;
            return fixture;
        })
        {
            
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InlineAutoDomainDataAttribute : InlineAutoDataAttribute
    {
        public InlineAutoDomainDataAttribute(params object[] values) : base(new AutoDomainDataAttribute(), values)
        {
        }
    }

    
}
