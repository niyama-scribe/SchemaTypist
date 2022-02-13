using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;

namespace SchemaTypist.TestBase.Autofixture
{
    /// <summary>
    /// This is the only interface that the consumer of the library has to implement.
    /// This allows you to specify the Autofixture customizations to be used for your tests.
    /// </summary>
    public interface IAutofixtureCustomizationsSpecifier
    {
        IEnumerable<ICustomization> SpecifyCustomizations();
    }

    internal class DefaultAutofixtureCustomizationsSpecifier : IAutofixtureCustomizationsSpecifier
    {
        public IEnumerable<ICustomization> SpecifyCustomizations()
        {
            return new List<ICustomization>()
            {
            };
        }
    }
}
