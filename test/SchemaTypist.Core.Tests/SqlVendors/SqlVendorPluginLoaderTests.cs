using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Auzaar.AutoFixture;
using FluentAssertions;
using Moq;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.SqlVendors;
using SchemaTypist.Core.Utilities;
using Xunit;

namespace SchemaTypist.Core.Tests.SqlVendors
{
    public class SqlVendorPluginLoaderTests
    {
        [Theory]
        [AutoTestParams]
        internal void GetSqlVendor_WithoutCallingLoadRegisteredVendors_ThrowsInvalidOpException(SqlVendorPluginLoader sut)
        {
            //Arrange
            
            //Act
            sut.Invoking(svp => svp.GetSqlVendor(It.IsAny<SqlVendorType>()))

            //Assert    
                .Should().Throw<InvalidOperationException>()
                .WithMessage($"Please call {nameof(sut.LoadRegisteredVendors)} first.");
        }

        [Theory]
        [AutoTestParams]
        internal void GetSqlVendor_WithNoRegisteredVendors_ThrowsInvalidOpException([Frozen] Mock<IPluginLoader> pluginLoader, SqlVendorPluginLoader sut)
        {
            //Arrange
            pluginLoader.Setup(pl => pl.FindPlugins<ISqlVendor>(It.IsAny<string>(), typeof(SqlVendorDefinition))).Returns(Array.Empty<ISqlVendor>());
            
            //Act
            sut.LoadRegisteredVendors();
            sut.Invoking(svp => svp.GetSqlVendor(It.IsAny<SqlVendorType>()))

                //Assert    
                .Should().Throw<InvalidOperationException>()
                .WithMessage($"We don't seem to have any SqlVendor libraries referenced which shouldn't happen.  Please reference at least one of the SqlVendor libraries.");
        }

        [Theory]
        [AutoTestParams]
        internal void GetSqlVendor_WithOneRegisteredImpl_UseThatRegisteredImplRegardlessOfRequestedSqlVendorType(
            [Frozen] Mock<IPluginLoader> pluginLoader, [Frozen] Mock<ISqlVendor> sqlVendor, 
            SqlVendorPluginLoader sut)
        {
            //Arrange
            sqlVendor.SetupGet(sv => sv.VendorType).Returns(SqlVendorType.PostgreSql);
            pluginLoader.Setup(pl => pl.FindPlugins<ISqlVendor>(It.IsAny<string>(), typeof(SqlVendorDefinition))).Returns(new [] {sqlVendor.Object});
            
            //Act
            sut.LoadRegisteredVendors();
            var sv = sut.GetSqlVendor(SqlVendorType.MicrosoftSqlServer);

            //Assert    
            sv.Should().Be(sqlVendor.Object);
            sv.VendorType.Should().Be(SqlVendorType.PostgreSql);
        }

        [Theory]
        [AutoTestParamsInlineData(SqlVendorType.MicrosoftSqlServer)]
        [AutoTestParamsInlineData(SqlVendorType.PostgreSql)]
        internal void GetSqlVendor_WithMultipleRegisteredImpl_UseMatchingRegisteredImplBasedOnRequestedSqlVendorType(
            SqlVendorType input, [Frozen] Mock<IPluginLoader> pluginLoader, Mock<ISqlVendor> msVendor, 
            Mock<ISqlVendor> postgresVendor, SqlVendorPluginLoader sut)
        {
            //Arrange
            msVendor.SetupGet(sv => sv.VendorType).Returns(SqlVendorType.MicrosoftSqlServer);
            postgresVendor.SetupGet(sv => sv.VendorType).Returns(SqlVendorType.PostgreSql);

            pluginLoader.Setup(pl => pl.FindPlugins<ISqlVendor>(It.IsAny<string>(), typeof(SqlVendorDefinition)))
                .Returns(new[] { msVendor.Object, postgresVendor.Object });
            
            //Act
            sut.LoadRegisteredVendors();
            var sv = sut.GetSqlVendor(input);

            //Assert    
            sv.VendorType.Should().Be(input);
        }
    }
}
