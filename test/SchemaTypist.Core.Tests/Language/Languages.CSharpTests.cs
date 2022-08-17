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
        [AutoTestParamsInlineData("string", true, true, "string?")]
        [AutoTestParamsInlineData("string", false, true, "string")]
        [AutoTestParamsInlineData("string", true, false, "string")]
        [AutoTestParamsInlineData("string", false, false, "string")]
        [AutoTestParamsInlineData("BitArray", true, true, "BitArray?")]
        [AutoTestParamsInlineData("BitArray", false, true, "BitArray")]
        [AutoTestParamsInlineData("BitArray", true, false, "BitArray")]
        [AutoTestParamsInlineData("BitArray", false, false, "BitArray")]
        [AutoTestParamsInlineData("UnknownType", true, true, "UnknownType")]
        [AutoTestParamsInlineData("UnknownType", false, true, "UnknownType")]
        [AutoTestParamsInlineData("UnknownType", true, false, "UnknownType")]
        [AutoTestParamsInlineData("UnknownType", false, false, "UnknownType")]
        internal void HandleNullability_WhenGivenCsharpTypeName_IdentifiesRefType(string typeName, bool canBeSetToNull,
            bool useNullableRefType, string expected)
        {
            //Arrange
            var f = new Fixture();
            var config = f.Build<CodeGenConfig>().With(cgc => cgc.UseNullableRefTypes, useNullableRefType).Create();

            //Act
            var actual = Languages.CSharp.HandleNullability(typeName, canBeSetToNull, config);

            //Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [AutoTestParamsInlineData("string", false)]
        [AutoTestParamsInlineData("string?", true)]
        [AutoTestParamsInlineData("int", false)]
        [AutoTestParamsInlineData("int?", true)]
        [AutoTestParamsInlineData(null, false)]
        [AutoTestParamsInlineData("", false)]
        internal void IsNullable_WhenGivenCsharpTypeName_DeterminesNullability(string typeName, bool expected)
        {
            //Arrange

            //Act
            var actual = Languages.CSharp.IsNullable(typeName);

            //Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [AutoTestParamsInlineData(null, false)]
        [AutoTestParamsInlineData("", false)]
        [AutoTestParamsInlineData("string", true)]
        [AutoTestParamsInlineData("string?", true)]
        [AutoTestParamsInlineData("int", false)]
        [AutoTestParamsInlineData("int?", false)]
        [AutoTestParamsInlineData("UnknownType", false)]
        [AutoTestParamsInlineData("UnknownType?", false)]
        internal void IsReferenceType_WhenGivenCsharpTypeName_DeterminesTypeCategory(string typeName, bool expected)
        {
            //Arrange

            //Act
            var actual = Languages.CSharp.IsReferenceType(typeName);

            //Assert
            actual.Should().Be(expected);
        }
        
    }
}
