using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.AutoMoq;
using SchemaTypist.Core.Tests.Autofixture;

namespace SchemaTypist.Core.Tests
{
    /// <summary>
    /// Using module initializer to register all the
    /// autofixture customizations I need
    /// </summary>
    public static class ModuleInit
    {
        [ModuleInitializer]
        public static void Initialize()
        {
            FixtureCustomizationsRegistrar.Default.Register(
                new FakesCustomization(), 
                new AutoMoqCustomization());
        }
    }
}
