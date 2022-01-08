using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.SqlVendors;
using SchemaTypist.Core.Utilities;
using Xunit;

namespace SchemaTypist.Core.Tests.SqlVendors
{
    public class SqlVendorProviderTests
    {
        [Fact]
        public void GetSqlVendor_WithoutCallingLoadRegisteredVendors_ThrowsInvalidOpException()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sut = fixture.Create<SqlVendorProvider>();

            //Act
            sut.Invoking(svp => svp.GetSqlVendor(It.IsAny<SqlVendorType>()))

            //Assert    
                .Should().Throw<InvalidOperationException>()
                .WithMessage($"Please call {nameof(sut.LoadRegisteredVendors)} first.");
        }

        [Fact]
        public void GetSqlVendor_WithNoRegisteredVendors_ThrowsInvalidOpException()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var pluginLoader = fixture.Freeze<Mock<IPluginLoader>>();
            pluginLoader.Setup(pl => pl.FindPlugins<ISqlVendor>(It.IsAny<string>(), typeof(SqlVendorDefinition))).Returns(Array.Empty<ISqlVendor>());
            var sut = fixture.Create<SqlVendorProvider>();

            //Act
            sut.LoadRegisteredVendors();
            sut.Invoking(svp => svp.GetSqlVendor(It.IsAny<SqlVendorType>()))

                //Assert    
                .Should().Throw<InvalidOperationException>()
                .WithMessage($"We don't seem to have any SqlVendor libraries referenced which shouldn't happen.  Please reference at least one of the SqlVendor libraries.");
        }

        [Fact]
        public void GetSqlVendor_WithOneRegisteredImpl_UseThatRegisteredImplRegardlessOfRequestedSqlVendorType()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var pluginLoader = fixture.Freeze<Mock<IPluginLoader>>();
            var sqlVendor = fixture.Freeze<Mock<ISqlVendor>>();
            sqlVendor.SetupGet(sv => sv.VendorType).Returns(SqlVendorType.PostgreSql);
            pluginLoader.Setup(pl => pl.FindPlugins<ISqlVendor>(It.IsAny<string>(), typeof(SqlVendorDefinition))).Returns(new [] {sqlVendor.Object});
            var sut = fixture.Create<SqlVendorProvider>();

            //Act
            sut.LoadRegisteredVendors();
            var sv = sut.GetSqlVendor(SqlVendorType.MicrosoftSqlServer);

            //Assert    
            sv.Should().Be(sqlVendor.Object);
            sv.VendorType.Should().Be(SqlVendorType.PostgreSql);
        }

        [Theory]
        [InlineData(SqlVendorType.MicrosoftSqlServer)]
        [InlineData(SqlVendorType.PostgreSql)]
        public void GetSqlVendor_WithMultipleRegisteredImpl_UseMatchingRegisteredImplBasedOnRequestedSqlVendorType(SqlVendorType input)
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var pluginLoader = fixture.Freeze<Mock<IPluginLoader>>();
            var msVendor = new Mock<ISqlVendor>();
            msVendor.SetupGet(sv => sv.VendorType).Returns(SqlVendorType.MicrosoftSqlServer);
            var postgresVendor = new Mock<ISqlVendor>();
            postgresVendor.SetupGet(sv => sv.VendorType).Returns(SqlVendorType.PostgreSql);

            pluginLoader.Setup(pl => pl.FindPlugins<ISqlVendor>(It.IsAny<string>(), typeof(SqlVendorDefinition)))
                .Returns(new[] { msVendor.Object, postgresVendor.Object });
            var sut = new SqlVendorProvider(pluginLoader.Object);

            //Act
            sut.LoadRegisteredVendors();
            var sv = sut.GetSqlVendor(input);

            //Assert    
            sv.VendorType.Should().Be(input);
        }
    }
}
