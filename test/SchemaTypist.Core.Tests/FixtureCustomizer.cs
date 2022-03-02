using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Auzaar.AutoFixture;

namespace SchemaTypist.Core.Tests
{
    internal class FixtureCustomizer : IAutofixtureCustomizationsSpecifier
    {
        public IEnumerable<ICustomization> SpecifyCustomizations()
        {
            //These can be any implementations of ICustomization or ISpecimenBuilder
            //Choose to extend CustomTypeSpecimenBuilderBase<T> to make it even easier!
            var l = new List<ICustomization>()
            {
                new FakesCustomization(),
                new FileSystemWrapperSpecimenBuilder().ToCustomization(),
                new AutoMoqCustomization()
            };
            return l;
        }
    }
}
