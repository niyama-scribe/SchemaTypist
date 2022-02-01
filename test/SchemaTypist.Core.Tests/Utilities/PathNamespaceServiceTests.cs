using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.Utilities;
using Xunit;

namespace SchemaTypist.Core.Tests.Utilities
{
    public class PathNamespaceServiceTests
    {
        [Theory]
        [InlineAutoDomainData("Company.Product", "Generated", "Domain", "Persistence", "Company.Product.Generated.Domain", "Company.Product.Generated.Persistence")]
        [InlineAutoDomainData("Company.Product", null, "Domain", "Persistence", "Company.Product.Domain", "Company.Product.Persistence")]
        [InlineAutoDomainData("Company.Product", " ", "Domain", "Persistence", "Company.Product.Domain", "Company.Product.Persistence")]
        [InlineAutoDomainData("Company.Product", "Generated", null, "Persistence", "Company.Product.Generated", "Company.Product.Generated.Persistence")]
        [InlineAutoDomainData("Company.Product", "Generated", " ", "Persistence", "Company.Product.Generated", "Company.Product.Generated.Persistence")]
        [InlineAutoDomainData("Company.Product", "Generated", "Domain", null, "Company.Product.Generated.Domain", "Company.Product.Generated")]
        [InlineAutoDomainData("Company.Product", "Generated", "Domain", " ", "Company.Product.Generated.Domain", "Company.Product.Generated")]
        internal void Resolve_Namespaces_WithoutCustomNamespacesInput_SetToFormattedValueBasedOnDirStructure(
            string rootNs, string rootOutputDir, string entitiesOutputDir,
            string persistenceOutputDir, string expectedEntitiesNs, string expectedPersistenceNs,
            PathNamespaceService sut)
        {
            //Arrange
            var fixture = new Fixture();
            var codeGenConfig = fixture.Build<CodeGenConfig>()
                .With(cgc => cgc.RootNamespace, rootNs)
                .With(cgc => cgc.RootOutputDirectory, rootOutputDir)
                .With(cgc => cgc.EntitiesOutputDirectory, entitiesOutputDir)
                .With(cgc => cgc.PersistenceOutputDirectory, persistenceOutputDir)
                .Without(cgc => cgc.EntitiesCustomNamespace)
                .Without(cgc => cgc.PersistenceCustomNamespace)
                .Create();
            var tabStructure = fixture.Build<TabularStructure>()
                .With(ts => ts.Schema, "Public")
                .Create();


            //Act
            var actual = sut.Resolve(codeGenConfig, tabStructure);

            //Assert
            actual.EntitiesNamespace.Should().Be($"{expectedEntitiesNs}.Public");
            actual.PersistenceNamespace.Should().Be($"{expectedPersistenceNs}.Public");
        }

        [Theory]
        [InlineAutoDomainData("Company.Product", "Generated", "Domain", "Persistence", "Generated/Domain", "Generated/Persistence")]
        [InlineAutoDomainData("Company.Product", null, "Domain", "Persistence", "Domain", "Persistence")]
        [InlineAutoDomainData("Company.Product", " ", "Domain", "Persistence", "Domain", "Persistence")]
        [InlineAutoDomainData("Company.Product", "Generated", null, "Persistence", "Generated", "Generated/Persistence")]
        [InlineAutoDomainData("Company.Product", "Generated", " ", "Persistence", "Generated", "Generated/Persistence")]
        [InlineAutoDomainData("Company.Product", "Generated", "Domain", null, "Generated/Domain", "Generated")]
        [InlineAutoDomainData("Company.Product", "Generated", "Domain", " ", "Generated/Domain", "Generated")]
        internal void Resolve_Directories_BuildsDirectoryHierarchy(
            string rootNs, string rootOutputDir, string entitiesOutputDir,
            string persistenceOutputDir, string expectedEntitiesFilePath, string expectedPersistenceRootFilePath,
            IFileSystemWrapper fileSystemWrapper, PathNamespaceService sut)
        {
            //Arrange
            var fixture = new Fixture();
            var codeGenConfig = fixture.Build<CodeGenConfig>()
                .With(cgc => cgc.RootNamespace, rootNs)
                .With(cgc => cgc.RootOutputDirectory, rootOutputDir)
                .With(cgc => cgc.EntitiesOutputDirectory, entitiesOutputDir)
                .With(cgc => cgc.PersistenceOutputDirectory, persistenceOutputDir)
                .With(cgc => cgc.OutputFileNameSuffix, "g")
                .With(cgc => cgc.EntityNameSuffix, "Entity")
                .With(cgc => cgc.MapperNameSuffix, "Mapper")
                .Without(cgc => cgc.EntitiesCustomNamespace)
                .Without(cgc => cgc.PersistenceCustomNamespace)
                .Create();
            var tabStructure = fixture.Build<TabularStructure>()
                .With(ts => ts.Schema, "Public")
                .With(ts => ts.Name, "SomeModel")
                .Create();


            //Act
            var actual = sut.Resolve(codeGenConfig, tabStructure);

            //Assert
            actual.EntitiesFilePath.Should()
                .Be($"{fileSystemWrapper.CurrentDirectory}/{expectedEntitiesFilePath}/Public/SomeModelEntity.g.cs");
            actual.PersistenceFilePath.Should()
                .Be(
                    $"{fileSystemWrapper.CurrentDirectory}/{expectedPersistenceRootFilePath}/Public/SomeModelMapper.g.cs");
            actual.DapperInitialiserFilePath.Should()
                .Be($"{fileSystemWrapper.CurrentDirectory}/{expectedPersistenceRootFilePath}/DapperTypeMapping.g.cs");
    }

        [Theory]
        [InlineAutoDomainData("Company.Product", "Generated/Location", "Domain/Model", "Persistence/Dao")]
        [InlineAutoDomainData("Company.Product", @"Magical\Location", @"Entities\Design", @"Dal\Layer")]
        internal void Resolve_Namespaces_WithDirectoryHierarchyAsInput_SetToFormattedValueBasedOnDirStructure(
            string rootNs, string rootOutputDir, string entitiesOutputDir,
            string persistenceOutputDir, PathNamespaceService sut)
        {
            //Arrange
            var fixture = new Fixture();
            var codeGenConfig = fixture.Build<CodeGenConfig>()
                .With(cgc => cgc.RootNamespace, rootNs)
                .With(cgc => cgc.RootOutputDirectory, rootOutputDir)
                .With(cgc => cgc.EntitiesOutputDirectory, entitiesOutputDir)
                .With(cgc => cgc.PersistenceOutputDirectory, persistenceOutputDir)
                .Without(cgc => cgc.EntitiesCustomNamespace)
                .Without(cgc => cgc.PersistenceCustomNamespace)
                .Create();
            var tabStructure = fixture.Build<TabularStructure>()
                .With(ts => ts.Schema, "Public")
                .Create();


            //Act
            var actual = sut.Resolve(codeGenConfig, tabStructure);

            //Assert
            actual.EntitiesNamespace.Should().Be($"{rootNs}.{rootOutputDir.Replace('/', '.').Replace('\\', '.')}.{entitiesOutputDir.Replace('/', '.').Replace('\\', '.')}.Public");
            actual.PersistenceNamespace.Should().Be($"{rootNs}.{rootOutputDir.Replace('/', '.').Replace('\\', '.')}.{persistenceOutputDir.Replace('/', '.').Replace('\\', '.')}.Public");
        }

        [Theory]
        [InlineAutoDomainData("Company.Product", "Generated", "Domain", "Persistence", "EntitiesCustomNamespace", "PersistenceCustomNamespace")]
        internal void Resolve_Namespaces_WithCustomNamespacesInput_SetToFormattedValueBasedOnDirStructureAndCustomNs(
            string rootNs, string rootOutputDir, string entitiesOutputDir,
            string persistenceOutputDir, string entitiesCustomNs, string persistenceCustomNs,
            PathNamespaceService sut)
        {
            //Arrange
            var fixture = new Fixture();
            var codeGenConfig = fixture.Build<CodeGenConfig>()
                .With(cgc => cgc.RootNamespace, rootNs)
                .With(cgc => cgc.RootOutputDirectory, rootOutputDir)
                .With(cgc => cgc.EntitiesOutputDirectory, entitiesOutputDir)
                .With(cgc => cgc.PersistenceOutputDirectory, persistenceOutputDir)
                .With(cgc => cgc.EntitiesCustomNamespace, entitiesCustomNs)
                .With(cgc => cgc.PersistenceCustomNamespace, persistenceCustomNs)
                .Create();
            var tabStructure = fixture.Build<TabularStructure>()
                .With(ts => ts.Schema, "Public")
                .Create();


            //Act
            var actual = sut.Resolve(codeGenConfig, tabStructure);

            //Assert
            actual.EntitiesNamespace.Should().Be("Company.Product.Generated.Domain.EntitiesCustomNamespace.Public");
            actual.PersistenceNamespace.Should().Be("Company.Product.Generated.Persistence.PersistenceCustomNamespace.Public");
        }

    }
}
