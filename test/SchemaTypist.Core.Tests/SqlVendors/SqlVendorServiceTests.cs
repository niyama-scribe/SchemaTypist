using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.SqlVendors;
using SchemaTypist.Core.Utilities;
using SqlKata.Compilers;
using Xunit;

namespace SchemaTypist.Core.Tests.SqlVendors
{
    public class SqlVendorServiceTests
    {
        [Theory]
        [InlineData("datetime", false, "DateTime")]
        [InlineData("datetime", true, "DateTime?")]
        public void DetermineDotnetDataType_WhenValid_GetsDataTypeAsPerDialect(string sqlDataType, bool isNullable, string dotnetDataType)
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sd = fixture.Freeze<Mock<ISqlDialect>>();
            sd.Setup(d => d.DetermineDotNetDataType(sqlDataType, isNullable)).Returns(dotnetDataType);
            var sv = fixture.Freeze<Mock<ISqlVendor>>();
            sv.SetupGet(v => v.Dialect).Returns(sd.Object);
            var svp = fixture.Freeze<Mock<ISqlVendorProvider>>();
            svp.Setup(p => p.GetSqlVendor(It.IsAny<SqlVendorType>())).Returns(sv.Object);
            var cdc = fixture.Create<CodeGenConfig>();
            var sut = fixture.Create<SqlVendorService>();

            //Act
            var actual = sut.DetermineDotNetDataType(sqlDataType, isNullable, cdc);

            //Assert
            actual.Should().Be(dotnetDataType);
        }

        [Fact]
        public void BuildQualifiedName_WhenValid_UsesRegisteredImpl()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sd = fixture.Freeze<Mock<ISqlDialect>>();
            sd.Setup(sd => sd.BuildQualifiedName(It.IsAny<TabularStructure>()))
                .Returns("abracadabra");
            var sv = fixture.Freeze<Mock<ISqlVendor>>();
            sv.SetupGet(v => v.Dialect).Returns(sd.Object);
            var svp = fixture.Freeze<Mock<ISqlVendorProvider>>();
            svp.Setup(p => p.GetSqlVendor(It.IsAny<SqlVendorType>())).Returns(sv.Object);
            var cdc = fixture.Create<CodeGenConfig>();
            var sut = fixture.Create<SqlVendorService>(); 
            var tabularStructure = fixture.Create<TabularStructure>();
            
            //Act
            var retVal = sut.BuildQualifiedName(tabularStructure, cdc);

            //Assert
            retVal.Should().Be("abracadabra");
        }

        [Fact]
        public void GetDbInterfaceProviders_WhenValid_UsesRegisteredImpl()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var dbConnection = fixture.Freeze<IDbConnection>();
            var compiler = Mock.Of<Compiler>();
            var sv = fixture.Freeze<Mock<ISqlVendor>>();
            sv.Setup(sv => sv.GetDbInterfaceProviders(It.IsAny<CodeGenConfig>()))
                .Returns((dbConnection, compiler));
            var svp = fixture.Freeze<Mock<ISqlVendorProvider>>();
            svp.Setup(p => p.GetSqlVendor(It.IsAny<SqlVendorType>())).Returns(sv.Object);
            var cdc = fixture.Build<CodeGenConfig>().With(c => c.Vendor, SqlVendorType.MicrosoftSqlServer).Create();
            var sut = fixture.Create<SqlVendorService>();
            
            //Act
            var (dbConn, cpl) = sut.GetDbInterfaceProviders(cdc);

            //Assert
            dbConn.Should().Be(dbConnection);
            cpl.Should().Be(compiler);
        }
    }
}
