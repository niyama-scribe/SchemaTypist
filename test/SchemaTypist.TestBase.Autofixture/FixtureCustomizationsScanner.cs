using AutoFixture;

namespace SchemaTypist.TestBase.Autofixture
{
    /// <summary>
    /// This class serves as the registry for autofixture customizations.
    /// It will be used by 
    /// </summary>
    public class FixtureCustomizationsScanner
    {
        private static readonly Lazy<List<ICustomization>> Registry = new Lazy<List<ICustomization>>(DiscoverCustomizations);
        
        private static List<ICustomization> DiscoverCustomizations()
        {
            var matchingTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes()
                    .Where(t => typeof(IAutofixtureCustomizationsProvider).IsAssignableFrom(t)));
            var type = matchingTypes.First() ?? typeof(DefaultAutofixtureCustomizationsProvider);
            if (Activator.CreateInstance(type) is IAutofixtureCustomizationsProvider customizationsProvider)
                return customizationsProvider.ProvideCustomizations().ToList();
            return new List<ICustomization>();
        }

        public static CompositeCustomization Compose()
        {
            //If this is the first attempt
            return new CompositeCustomization(Registry.Value);
        }


    }
}
