using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using SchemaTypist.Core.Config;
using Xunit;
using SchemaTypist.Core.Naming;

namespace SchemaTypist.Core.Tests.Language
{
    public class LanguageServiceTests
    {
        private INamingService _sut = new LanguageService();
        [Fact]
        public void ConvertCatalogName_ConflictFreeName_ReturnsPascalizedName()
        {
            //Arrange
            var fixture = new Fixture();
            var proposedName = fixture.Create<string>("some_name");
            var config = fixture.Build<CodeGenConfig>()
                .Create();

            //Act
            var catalogName = _sut.ConvertCatalogName(proposedName, config);

            //Assert
            catalogName.Should().StartWith("SomeName").And.NotContain($"{config.NamingConflictResolutionSuffix}");
        }

        [Fact]
        public void ConvertCatalogName_ConflictWithCSharpKeyword_PascalCase_ReturnsPascalizedNameWithConflictResolverSuffix()
        {
            //Arrange
            var fixture = new Fixture();
            var proposedName = "IntPtr";
            var config = fixture.Build<CodeGenConfig>()
                .Without(cdc => cdc.NamingConflictResolutionSuffix)
                .Create();

            //Act
            var catalogName = _sut.ConvertCatalogName(proposedName, config);

            //Assert
            catalogName.Should().Be($"IntPtr{config.NamingConflictResolutionSuffix}");
        }

        [Fact]
        public void ConvertCatalogName_ConflictWithCSharpKeyword_LowerCase_ReturnsPascalizedName()
        {
            //Arrange
            var fixture = new Fixture();
            var proposedName = "internal";
            var config = fixture.Build<CodeGenConfig>()
                .Without(cdc => cdc.NamingConflictResolutionSuffix)
                .Create();

            //Act
            var catalogName = _sut.ConvertCatalogName(proposedName, config);

            //Assert
            catalogName.Should().Be("Internal");
        }

        [Fact]
        public void ConvertCatalogName_ConflictWithSqlKeyword_CaseInsensitive_ReturnsPascalizedName()
        {
            //Arrange
            var fixture = new Fixture();
            var proposedName = "constraint";
            var config = fixture.Build<CodeGenConfig>()
                .Without(cdc => cdc.NamingConflictResolutionSuffix)
                .With(cdc => cdc.Vendor, SqlVendorType.MicrosoftSqlServer)
                .Create();

            //Act
            var catalogName = _sut.ConvertCatalogName(proposedName, config);

            //Assert
            catalogName.Should().Be("Constraint");
        }

    }
}
