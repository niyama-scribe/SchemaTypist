using AutoFixture.Xunit2;

namespace SchemaTypist.TestBase.Autofixture;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class InlineAutoDataTestParamsAttribute : InlineAutoDataAttribute
{
    public InlineAutoDataTestParamsAttribute(params object[] values) 
        : base(new AutoTestParamsAttribute(), values)
    {
    }
}