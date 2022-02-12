using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Kernel;

namespace SchemaTypist.TestBase.Autofixture
{
    public abstract class BaseTypeSpecimenBuilder<T> : ISpecimenBuilder
    {
        public object? Create(object request, ISpecimenContext context)
        {
            var type = request as Type;
            if (type == null || type != typeof(T)) return new NoSpecimen();
            return BuildSpecimen();
        }

        protected abstract T? BuildSpecimen();
    }
}
