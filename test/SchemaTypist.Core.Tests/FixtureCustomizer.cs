﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using SchemaTypist.TestBase.Autofixture;

namespace SchemaTypist.Core.Tests
{
    internal class FixtureCustomizer : IAutofixtureCustomizationsProvider
    {
        public IEnumerable<ICustomization> ProvideCustomizations()
        {
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