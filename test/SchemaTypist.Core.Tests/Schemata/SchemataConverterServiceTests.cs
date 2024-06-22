using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using Auzaar.AutoFixture;
using FluentAssertions;
using Moq;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Naming;
using SchemaTypist.Core.Schemata;
using SchemaTypist.Core.Schemata.Dto;
using SchemaTypist.Core.SqlVendors;
using Xunit;

namespace SchemaTypist.Core.Tests.Schemata
{
    public class SchemataConverterServiceTests
    {
        [Theory]
        [AutoTestParams]
        internal void Convert_WhenQualifiedTableNameIsExcluded_WillBeIgnored(
            SchemataConverterService sut)
        {
            //Arrange
            var columnsList = new List<ColumnsDto>();
            var fixture = new Fixture();
            var columns = fixture.Build<ColumnsDto>().With(dto => dto.TableSchema, "public").CreateMany();
            columnsList.AddRange(columns);
            columnsList.AddRange(fixture.CreateMany<ColumnsDto>());
            var cdc = fixture.Build<CodeGenConfig>()
                .With(c => c.Exclude, "*public*")
                .Without(c => c.Include)
                .Create();
            
            //Act
            var tabStructures = sut.Convert(columnsList, cdc);

            //Assert
            foreach (var (key, val) in tabStructures)
            {
                key.Should().NotContain("public"); 
                val.SqlSchema.Should().NotBe("public");
            }
        }

        [Theory]
        [AutoTestParamsInlineData("string", "null", true, true, "default!")]
        [AutoTestParamsInlineData("string?", "null", true, true, null)]
        [AutoTestParamsInlineData("string", "null", true, false, null)]
        [AutoTestParamsInlineData("string?", "null", true, false, null)]
        [AutoTestParamsInlineData("string", "", true, true, "default!")]
        [AutoTestParamsInlineData("string?", "", true, true, null)]
        [AutoTestParamsInlineData("string", "", true, false, null)]
        [AutoTestParamsInlineData("string?", "", true, false, null)]
        [AutoTestParamsInlineData("string", null, true, true, "default!")]
        [AutoTestParamsInlineData("string?", null, true, true, null)]
        [AutoTestParamsInlineData("string", null, true, false, null)]
        [AutoTestParamsInlineData("string?", null, true, false, null)]
        [AutoTestParamsInlineData("string", "\"abc\"", true, true, "\"abc\"")]
        [AutoTestParamsInlineData("string?", "\"abc\"", true, true, "\"abc\"")]
        [AutoTestParamsInlineData("string", "\"abc\"", true, false, "\"abc\"")]
        [AutoTestParamsInlineData("string?", "\"abc\"", true, false, "\"abc\"")]
        
        [AutoTestParamsInlineData("string", "null", false, true, "default!")]
        [AutoTestParamsInlineData("string?", "null", false, true, null)]
        [AutoTestParamsInlineData("string", "null", false, false, null)]
        [AutoTestParamsInlineData("string?", "null", false, false, null)]
        [AutoTestParamsInlineData("string", "", false, true, "default!")]
        [AutoTestParamsInlineData("string?", "", false, true, null)]
        [AutoTestParamsInlineData("string", "", false, false, null)]
        [AutoTestParamsInlineData("string?", "", false, false, null)]
        [AutoTestParamsInlineData("string", null, false, true, "default!")]
        [AutoTestParamsInlineData("string?", null, false, true, null)]
        [AutoTestParamsInlineData("string", null, false, false, null)]
        [AutoTestParamsInlineData("string?", null, false, false, null)]
        [AutoTestParamsInlineData("string", "\"abc\"", false, true, "default!")]
        [AutoTestParamsInlineData("string?", "\"abc\"", false, true, null)]
        [AutoTestParamsInlineData("string", "\"abc\"", false, false, null)]
        [AutoTestParamsInlineData("string?", "\"abc\"", false, false, null)]

        internal void Convert_OverridesDefaultValueWhenAppropriate(
            string datatype, string columnDefault, bool useSqlDefaultValue, bool useNullableRef, string expected,
            [Frozen] Mock<ISqlVendorService> sqlVendorService,
            SchemataConverterService sut)
        {
            //Arrange
            var columnsList = new List<ColumnsDto>();
            var fixture = new Fixture();
            var columns = fixture.Build<ColumnsDto>().CreateMany();
            columnsList.AddRange(columns);
            
            var cdc = fixture.Build<CodeGenConfig>()
                .With(cgc => cgc.TargetLanguageVersion, "Default")
                .With(c => c.UseNullableRefTypes, useNullableRef)
                .With(c => c.UseSqlDefaultValue, useSqlDefaultValue)
                .With(c => c.Include, "*")
                .Create();

            sqlVendorService.Setup(svs =>
                    svs.DetermineDotNetDataType(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<CodeGenConfig>()))
                .Returns(datatype);

            sqlVendorService.Setup(svs =>
                    svs.DetermineDefaultValue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CodeGenConfig>()))
                .Returns(columnDefault);

            
            //Act
            var tabStructures = sut.Convert(columnsList, cdc);

            //Assert
            tabStructures.SelectMany(tab => tab.Value.Columns).Select(c => c.DefaultValue).Should().AllBe(expected);

        }
    }
}
