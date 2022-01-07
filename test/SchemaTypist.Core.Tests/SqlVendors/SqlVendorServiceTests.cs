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
        [Fact]
        public void DetermineDotnetDataType_WhenSingleRegisteredImpl_UsesRegisteredImpl()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sqlDialect = fixture.Freeze<Mock<ISqlDialect>>();
            sqlDialect.Setup(sd => sd.DetermineDotNetDataType(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(nameof(DateTime));
            var sqlVendor = fixture.Freeze<Mock<ISqlVendor>>();
            sqlVendor.SetupGet(sv => sv.Dialect).Returns(sqlDialect.Object);
            var pluginLoader = fixture.Freeze<Mock<IPluginLoader>>();
            pluginLoader.Setup(pl => pl.FindPlugins<ISqlVendor>(It.IsAny<string>(), typeof(SqlVendorDefinition)))
                .Returns(new[] {sqlVendor.Object});
             var codeGenConfig = fixture.Build<CodeGenConfig>().With(cdc => cdc.Vendor, SqlVendorType.MicrosoftSqlServer).Create();
            
            var sut = fixture.Create<SqlVendorService>();


            //Act
            var dotnetDataType = sut.DetermineDotNetDataType("datetime", false, codeGenConfig);

            //Assert
            dotnetDataType.Should().Be(nameof(DateTime));
        }

        [Fact]
        public void DetermineDotnetDataType_WhenMutipleImplRegistered_UsesRegisteredImplBasedOnSqlVendorType()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var postgresDialect = new Mock<ISqlDialect>();
            postgresDialect.Setup(sd => sd.DetermineDotNetDataType(It.Is<string>(s => s.Equals("oid")), It.IsAny<bool>()))
                .Returns("uint");
            var postgresVendor = new Mock<ISqlVendor>();
            postgresVendor.SetupGet(sv => sv.Dialect).Returns(postgresDialect.Object);
            postgresVendor.SetupGet(sv => sv.VendorType).Returns(SqlVendorType.PostgreSql);
            var msDialect = new Mock<ISqlDialect>();
            msDialect.Setup(sd => sd.DetermineDotNetDataType(It.Is<string>(s => s.Equals("datetime")), It.IsAny<bool>()))
                .Returns(nameof(DateTime));
            var msVendor = new Mock<ISqlVendor>();
            msVendor.SetupGet(sv => sv.Dialect).Returns(msDialect.Object);
            msVendor.SetupGet(sv => sv.VendorType).Returns(SqlVendorType.MicrosoftSqlServer);
            
            var pluginLoader = fixture.Freeze<Mock<IPluginLoader>>();
            pluginLoader.Setup(pl => pl.FindPlugins<ISqlVendor>(It.IsAny<string>(), typeof(SqlVendorDefinition)))
                .Returns(new[] { postgresVendor.Object, msVendor.Object });
            var codeGenConfig = fixture.Build<CodeGenConfig>().With(cdc => cdc.Vendor, SqlVendorType.PostgreSql).Create();

            var sut = fixture.Create<SqlVendorService>();


            //Act
            var dotnetDataType = sut.DetermineDotNetDataType("oid", false, codeGenConfig);

            //Assert
            dotnetDataType.Should().Be("uint");
        }

        [Fact]
        public void DetermineDotNetDataType_WithNoImplsRegistered_ThrowsInvalidOperationException()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sqlDialect = fixture.Freeze<Mock<ISqlDialect>>();
            sqlDialect.Setup(sd => sd.DetermineDotNetDataType(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(nameof(DateTime));
            var sqlVendor = fixture.Freeze<Mock<ISqlVendor>>();
            sqlVendor.SetupGet(sv => sv.Dialect).Returns(sqlDialect.Object);
            var pluginLoader = fixture.Freeze<Mock<IPluginLoader>>();
            var codeGenConfig = fixture.Build<CodeGenConfig>().With(cdc => cdc.Vendor, SqlVendorType.MicrosoftSqlServer).Create();

            var sut = fixture.Create<SqlVendorService>();

            //Act
            sut.Invoking(s => s.DetermineDotNetDataType("anything", false, codeGenConfig)).Should()
                .Throw<InvalidOperationException>();

            //Assert
            
        }

        [Fact]
        public void BuildQualifiedName_WhenValid_UsesRegisteredImpl()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sqlDialect = fixture.Freeze<Mock<ISqlDialect>>();
            sqlDialect.Setup(sd => sd.BuildQualifiedName(It.IsAny<TabularStructure>()))
                .Returns("abracadabra");
            var sqlVendor = fixture.Freeze<Mock<ISqlVendor>>();
            sqlVendor.SetupGet(sv => sv.Dialect).Returns(sqlDialect.Object);
            var pluginLoader = fixture.Freeze<Mock<IPluginLoader>>();
            pluginLoader.Setup(pl => pl.FindPlugins<ISqlVendor>(It.IsAny<string>(), typeof(SqlVendorDefinition)))
                .Returns(new[] { sqlVendor.Object });
            var codeGenConfig = fixture.Build<CodeGenConfig>().With(cdc => cdc.Vendor, SqlVendorType.MicrosoftSqlServer).Create();
            var tabularStructure = fixture.Build<TabularStructure>().Create();

            var sut = fixture.Create<SqlVendorService>();


            //Act
            var retVal = sut.BuildQualifiedName(tabularStructure, codeGenConfig);

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
            var sqlVendor = fixture.Freeze<Mock<ISqlVendor>>();
            sqlVendor.Setup(sv => sv.GetDbInterfaceProviders(It.IsAny<CodeGenConfig>()))
                .Returns((dbConnection, compiler));
            var pluginLoader = fixture.Freeze<Mock<IPluginLoader>>();
            pluginLoader.Setup(pl => pl.FindPlugins<ISqlVendor>(It.IsAny<string>(), typeof(SqlVendorDefinition)))
                .Returns(new[] { sqlVendor.Object });
            var codeGenConfig = fixture.Build<CodeGenConfig>().With(cdc => cdc.Vendor, SqlVendorType.MicrosoftSqlServer).Create();
            
            var sut = fixture.Create<SqlVendorService>();


            //Act
            var (dbConn, cpl) = sut.GetDbInterfaceProviders(codeGenConfig);

            //Assert
            dbConn.Should().Be(dbConnection);
            cpl.Should().Be(compiler);
        }
    }
}
