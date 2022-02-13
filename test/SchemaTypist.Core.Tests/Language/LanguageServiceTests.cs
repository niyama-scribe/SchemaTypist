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
using SchemaTypist.TestBase.Autofixture;

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

        [Theory]
        [InlineAutoDataTestParams("tbl_,vw_,t_", "tbl_some_table_name", "SomeTableName")]
        [InlineAutoDataTestParams("tbl_,vw_,t_", "t_ThisEntity", "ThisEntity")]
        [InlineAutoDataTestParams("tbl_,vw_,t_", "vw_Some_Views", "SomeView")]
        [InlineAutoDataTestParams("tbl_,vw_,t_", "sans_removal", "SansRemoval")]
        [InlineAutoDataTestParams("tbl_,vw_,t_", "sans_removal_ignoreSuffix", "SansRemovalIgnoreSuffix")]
        [InlineAutoDataTestParams("", "tbl_some_table_name", "TblSomeTableName")]
        [InlineAutoDataTestParams(null, "tbl_some_table_name", "TblSomeTableName")]
        internal void ConvertTableName_WhenContainsPrefixesToBeStripped_ReturnsStrippedName(
            string stripPrefixes, string rawDatabaseObjectName, string expectedEntityName, LanguageService sut)
        {
            //Arrange
            var fixture = new Fixture();
            var proposedName = "tbl_SomeTableName";
            var config = fixture.Build<CodeGenConfig>()
                .Without(cdc => cdc.NamingConflictResolutionSuffix)
                .With(cdc => cdc.StripPrefix, stripPrefixes)
                .Create();

            //Act
            var actual = sut.ConvertTableName(rawDatabaseObjectName, config, "Unimportant");

            //Assert
            actual.Should().Be(expectedEntityName);
        }

        [Theory]
        [InlineAutoDataTestParams("_tbl,_vw,_t", "some_table_name", "SomeTableName")]
        [InlineAutoDataTestParams("_tbl,_vw,_t", "thisEntity_t", "ThisEntity")]
        [InlineAutoDataTestParams("_tbl,_vw,_t", "myObject_tbl", "MyObject")]
        [InlineAutoDataTestParams("_tbl,_vw,_t", "Some_Views_vw", "SomeView")]
        [InlineAutoDataTestParams("_tbl,_vw,_t", "sans_removal", "SansRemoval")]
        [InlineAutoDataTestParams("_tbl,_vw,_t", "ignorePrefix_sans_removal", "IgnorePrefixSansRemoval")]
        [InlineAutoDataTestParams("", "some_table_name_tbl", "SomeTableNameTbl")]
        [InlineAutoDataTestParams(null, "some_table_name_tbl", "SomeTableNameTbl")]
        internal void ConvertTableName_WhenContainsSuffixesToBeStripped_ReturnsStrippedName(
            string stripSuffixes, string rawDatabaseObjectName, string expectedEntityName, LanguageService sut)
        {
            //Arrange
            var fixture = new Fixture();
            var proposedName = "tbl_SomeTableName";
            var config = fixture.Build<CodeGenConfig>()
                .Without(cdc => cdc.NamingConflictResolutionSuffix)
                .With(cdc => cdc.StripSuffix, stripSuffixes)
                .Create();

            //Act
            var actual = sut.ConvertTableName(rawDatabaseObjectName, config, "Unimportant");

            //Assert
            actual.Should().Be(expectedEntityName);
        }

    }
}
