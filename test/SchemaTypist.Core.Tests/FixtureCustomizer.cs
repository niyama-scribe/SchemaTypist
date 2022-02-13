using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

// using SchemaTypist.TestBase.Autofixture;

namespace SchemaTypist.Core.Tests
{
    // internal class FixtureCustomizer : IAutofixtureCustomizationsProvider
    // {
    //     public IEnumerable<ICustomization> ProvideCustomizations()
    //     {
    //         var l = new List<ICustomization>()
    //         {
    //             new FakesCustomization(),
    //             new FileSystemWrapperSpecimenBuilder().ToCustomization(),
    //             new AutoMoqCustomization()
    //         };
    //         return l;
    //     }
    // }

    [AttributeUsage(AttributeTargets.Method)]
    public class AutoTestParamsAttribute : AutoDataAttribute
    {
        public AutoTestParamsAttribute()
            : base(() =>
            {
                var fixture = new Fixture()
                    .Customize(
                        new CompositeCustomization(
                            new FakesCustomization(),
                            new AutoMoqCustomization()
                            )
                        );
                return fixture;
            })
        {
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InlineAutoDataTestParamsAttribute : InlineAutoDataAttribute
    {
        public InlineAutoDataTestParamsAttribute(params object[] values)
            : base(new AutoTestParamsAttribute(), values)
        {
        }
    }
}
