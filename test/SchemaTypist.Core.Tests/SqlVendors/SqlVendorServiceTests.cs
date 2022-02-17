using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Dsl;
using AutoFixture.Xunit2;
using Auzaar.AutoFixture;
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
        [AutoTestParamsInlineData("datetime", false, "DateTime")]
        [AutoTestParamsInlineData("datetime", true, "DateTime?")]
        internal void DetermineDotnetDataType_WhenValid_GetsDataTypeAsPerDialect(
            string sqlDataType, bool isNullable, string dotnetDataType, 
            [Frozen] Mock<ISqlDialect> sd, [Frozen] Mock<ISqlVendor> sv, 
            [Frozen] Mock<ISqlVendorPluginLoader> svp, CodeGenConfig cdc, SqlVendorService sut)
        {
            //Arrange
            sd.Setup(d => d.DetermineDotNetDataType(sqlDataType, isNullable)).Returns(dotnetDataType);
            sv.SetupGet(v => v.Dialect).Returns(sd.Object);
            svp.Setup(p => p.GetSqlVendor(It.IsAny<SqlVendorType>())).Returns(sv.Object);
            
            //Act
            var actual = sut.DetermineDotNetDataType(sqlDataType, isNullable, cdc);

            //Assert
            actual.Should().Be(dotnetDataType);
        }

        [Theory]
        [AutoTestParams]
        internal void BuildQualifiedName_WhenValid_UsesRegisteredImpl(
            [Frozen] Mock<ISqlDialect> sd, [Frozen] Mock<ISqlVendor> sv,
            [Frozen] Mock<ISqlVendorPluginLoader> svp, CodeGenConfig cdc, 
            TabularStructure tabularStructure, SqlVendorService sut)
        {
            //Arrange
            sd.Setup(sd => sd.BuildQualifiedName(It.IsAny<TabularStructure>()))
                .Returns("abracadabra");
            sv.SetupGet(v => v.Dialect).Returns(sd.Object);
            svp.Setup(p => p.GetSqlVendor(It.IsAny<SqlVendorType>())).Returns(sv.Object);
            
            //Act
            var retVal = sut.BuildQualifiedName(tabularStructure, cdc);

            //Assert
            retVal.Should().Be("abracadabra");
        }

        [Theory]
        [AutoTestParams]
        internal void GetDbInterfaceProviders_WhenValid_UsesRegisteredImpl(
            [Frozen] IDbConnection dbConnection, [Frozen] Compiler compiler,
            [Frozen] Mock<ISqlVendor> sv, [Frozen] Mock<ISqlVendorPluginLoader> svp,
            CodeGenConfig cdc, SqlVendorService sut)
        {
            //Arrange
            sv.Setup(sv => sv.GetDbInterfaceProviders(It.IsAny<CodeGenConfig>()))
                .Returns((dbConnection, compiler));
            svp.Setup(p => p.GetSqlVendor(It.IsAny<SqlVendorType>())).Returns(sv.Object);
            cdc.Vendor = SqlVendorType.MicrosoftSqlServer;

            //Act
            var (dbConn, cpl) = sut.GetDbInterfaceProviders(cdc);

            //Assert
            dbConn.Should().Be(dbConnection);
            cpl.Should().Be(compiler);
        }
    }
}
