using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Xunit.Sdk;

namespace SchemaTypist.TestBase.Autofixture
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class MemberAutoDataTestParamsAttribute : MemberAutoDataAttribute
    {
        public MemberAutoDataTestParamsAttribute(string memberName, params object[] parameters) 
            : base(new AutoTestParamsAttribute(), memberName, parameters)
        {
        }
    }
}
