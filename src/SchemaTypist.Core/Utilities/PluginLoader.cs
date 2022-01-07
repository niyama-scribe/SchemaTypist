using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentAssemblyScanner;

namespace SchemaTypist.Core.Utilities
{
    internal class PluginLoader : IPluginLoader
    {
        public IEnumerable<T> FindPlugins<T>(String assemblyNamePrefix, Type attributeType)
        {
             var types = AssemblyScanner.FromAssemblyMatchingNamed(assemblyNamePrefix,
                    new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory))
                .BasedOn<T>()
                .HasAttribute(attributeType)
                .Filter()
                .Classes()
                .Scan();
             var expectedType = typeof(T);
             foreach (var type in types)
             {
                 if (expectedType.IsAssignableFrom(type))
                 yield return (T)Activator.CreateInstance(type);
             }
        }
    }

    public interface IPluginLoader
    {
        IEnumerable<T> FindPlugins<T>(String assemblyNamePrefix, Type attributeType);
    }
}
