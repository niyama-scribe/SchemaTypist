using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Auzaar.AutoFixture;
using FluentAssertions;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Language;
using Xunit;

namespace SchemaTypist.Core.Tests.Language
{
    public class LanguagesCSharpTests
    {
        [Theory]
        [AutoTestParamsInlineData("string", true, "string?")]
        [AutoTestParamsInlineData("string?", true, "string?")]
        [AutoTestParamsInlineData("string", false, "string")]
        [AutoTestParamsInlineData("BitArray", true, "BitArray?")]
        [AutoTestParamsInlineData("BitArray", false, "BitArray")]
        [AutoTestParamsInlineData("Abracadabra", true, "Abracadabra")]
        [AutoTestParamsInlineData("Abracadabra", false, "Abracadabra")]
        internal void HandleNullability_WhenGivenCsharpTypeName_IdentifiesRefType(string typeName, 
            bool useNullableRefType, string expected)
        {
            //Arrange
            var f = new Fixture();
            var config = f.Build<CodeGenConfig>().With(cgc => cgc.UseNullableRefTypes, useNullableRefType).Create();

            //Act
            var actual = Languages.CSharp.HandleNullability(typeName, config);

            //Assert
            actual.Should().Be(expected);
        }
    }
}
