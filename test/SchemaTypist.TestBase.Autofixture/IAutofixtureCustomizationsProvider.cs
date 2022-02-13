using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;

namespace SchemaTypist.TestBase.Autofixture
{
    public interface IAutofixtureCustomizationsProvider
    {
        IEnumerable<ICustomization> ProvideCustomizations();
    }

    internal class DefaultAutofixtureCustomizationsProvider : IAutofixtureCustomizationsProvider
    {
        public IEnumerable<ICustomization> ProvideCustomizations()
        {
            return new List<ICustomization>()
            {
            };
        }
    }
}
