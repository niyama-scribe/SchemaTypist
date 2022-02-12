using AutoFixture;

namespace SchemaTypist.TestBase.Autofixture
{
    /// <summary>
    /// This class serves as the registry for autofixture customizations.
    /// It will be used by 
    /// </summary>
    public class FixtureCustomizationsRegistrar
    {
        public static FixtureCustomizationsRegistrar Default { get; } = new FixtureCustomizationsRegistrar();

        private readonly List<ICustomization> _registry = new List<ICustomization>();

        public FixtureCustomizationsRegistrar Register(IEnumerable<ICustomization> customizations)
        {
            _registry.AddRange(customizations);
            return this;
        }

        public FixtureCustomizationsRegistrar Register(params ICustomization[] customizations)
        {
            if (customizations is not {Length: > 0}) return this;
            Register(customizations.ToList());
            return this;
        }

        public CompositeCustomization Compose()
        {
            return new CompositeCustomization(_registry);
        }


    }
}
