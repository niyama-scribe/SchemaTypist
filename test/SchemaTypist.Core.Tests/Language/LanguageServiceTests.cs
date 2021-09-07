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
using SchemaTypist.Core.Language;

namespace SchemaTypist.Core.Tests.Language
{
    public class LanguageServiceTests
    {
        [Fact]
        public void ConvertCatalogName_ConflictFreeName_ReturnsPascalizedName()
        {
            //Arrange
            var fixture = new Fixture();
            var proposedName = fixture.Create<string>("some_name");
            var config = fixture.Build<CodeGenConfig>().With(cdc => cdc.TargetLanguage, "CSharp").Create();

            //Act
            var catalogName = LanguageService.ConvertCatalogName(proposedName, config);

            //Assert
            catalogName.Should().StartWith("SomeName").And.NotContain("_");
        }
    }
}
