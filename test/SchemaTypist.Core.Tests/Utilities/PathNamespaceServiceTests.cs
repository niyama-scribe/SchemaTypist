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
            [Frozen]Mock<IFileSystemWrapper> fileSystemWrapperMock, PathNamespaceService sut)
        {
            //Arrange
            fileSystemWrapperMock.Setup(fsw=>fsw.AltDirectorySeparatorChar).Returns(() => '/');
            fileSystemWrapperMock.Setup(fsw => fsw.DirectorySeparatorChar).Returns(() => '\\');

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
        [InlineAutoDomainData("Company.Product", "Generated", "Domain", "Persistence", "Company.Product.Generated.Domain", "Company.Product.Generated.Persistence")]
        internal void Resolve_Directories_BuildsDirectoryHierarchy(
            string rootNs, string rootOutputDir, string entitiesOutputDir,
            string persistenceOutputDir, string expectedEntitiesNs, string expectedPersistenceNs,
            [Frozen] Mock<IFileSystemWrapper> fileSystemWrapperMock, PathNamespaceService sut)
        {
            //Arrange
            fileSystemWrapperMock.Setup(fsw => fsw.Combine(It.IsAny<string[]>())).Returns(() => '/');


            //Act

            //Assert
        }

        [Theory]
        [InlineAutoDomainData("Company.Product", "Generated/Location", "Domain/Model", "Persistence/Dao")]
        [InlineAutoDomainData("Company.Product", @"Magical\Location", @"Entities\Design", @"Dal\Layer")]
        internal void Resolve_Namespaces_WithDirectoryHierarchyAsInput_SetToFormattedValueBasedOnDirStructure(
            string rootNs, string rootOutputDir, string entitiesOutputDir,
            string persistenceOutputDir, [Frozen] Mock<IFileSystemWrapper> fileSystemWrapperMock,
            PathNamespaceService sut)
        {
            //Arrange
            fileSystemWrapperMock.Setup(fsw => fsw.AltDirectorySeparatorChar).Returns(() => '/');
            fileSystemWrapperMock.Setup(fsw => fsw.DirectorySeparatorChar).Returns(() => '\\');

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
            [Frozen] Mock<IFileSystemWrapper> fileSystemWrapperMock,
            PathNamespaceService sut)
        {
            //Arrange
            fileSystemWrapperMock.Setup(fsw => fsw.AltDirectorySeparatorChar).Returns(() => '/');
            fileSystemWrapperMock.Setup(fsw => fsw.DirectorySeparatorChar).Returns(() => '\\');

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
