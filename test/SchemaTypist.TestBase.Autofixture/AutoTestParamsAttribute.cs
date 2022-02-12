using AutoFixture;
using AutoFixture.Xunit2;

namespace SchemaTypist.TestBase.Autofixture
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AutoTestParamsAttribute : AutoDataAttribute
    {
        public AutoTestParamsAttribute() 
            : base(() =>
            {
                var fixture = new Fixture()
                    .Customize(FixtureCustomizationsRegistrar.Default.Compose());
                return fixture;
            })
        {
        }
    }
}
