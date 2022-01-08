using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
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
        [AutoDomainData]
        internal void Convert_WhenQualifiedTableNameIsExcluded_WillBeIgnored(
            [Frozen] INamingService namingSvc, [Frozen] ISqlVendorService sqlVendorSvc,
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
    }
}
