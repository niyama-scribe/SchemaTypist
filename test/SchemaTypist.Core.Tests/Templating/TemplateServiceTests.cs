using System;
using System.Linq;
using AutoFixture.Xunit2;
using Auzaar.AutoFixture;
using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.Templating;
using Xunit;

namespace SchemaTypist.Core.Tests.Templating;

public class TemplateServiceTests
{
    [Theory]
    [AutoTestParams]
    internal void GenerateEntities_WithoutLoadingTemplates_ThrowsInvalidOperationException(
        EntitiesTemplateModel model,
        TemplateService sut)
    {
        //Arrange

        //Act
        sut.Invoking(ts => ts.GenerateEntity(model)).Should().Throw<InvalidOperationException>();

        //Assert
    }

    [Theory]
    [AutoTestParams]
    internal void GeneratePersistence_WithoutLoadingTemplates_ThrowsInvalidOperationException(
        PersistenceTemplateModel model,
        TemplateService sut)
    {
        //Arrange

        //Act
        sut.Invoking(ts => ts.GeneratePersistence(model)).Should().Throw<InvalidOperationException>();

        //Assert
    }

    [Theory]
    [AutoTestParams]
    internal void GenerateDapperMapper_WithoutLoadingTemplates_ThrowsInvalidOperationException(
        DapperInitialiserTemplateModel model,
        TemplateService sut)
    {
        //Arrange

        //Act
        sut.Invoking(ts => ts.GenerateDapperMapper(model)).Should().Throw<InvalidOperationException>();

        //Assert
    }

    [Theory]
    [AutoTestParams]
    internal void GenerateEntity_CSharp7_3_Immutable_GeneratesBuilder(
        [Frozen] CodeGenConfig config, EntitiesTemplateModel model,
        TemplateService sut)
    {
        //Arrange
        config.TargetLanguageVersion = "CSharp7_3";
        config.CreateImmutableEntities = true;
        GenerateSchemaMetadataStub(config, model);

        sut.LoadTemplates(config);

        //Act
        var entityContent = sut.GenerateEntity(model);
        var syntaxTree = CSharpSyntaxTree.ParseText(entityContent);
        var root = syntaxTree.GetCompilationUnitRoot();
        var firstMember = root.Members[0] as NamespaceDeclarationSyntax;
        var firstClass = firstMember?.Members[0] as ClassDeclarationSyntax;
        var constructor = firstClass?.Members.FirstOrDefault(mds => mds.IsKind(SyntaxKind.ConstructorDeclaration))
            as ConstructorDeclarationSyntax;
        var innerClass = firstClass?
                .Members.FirstOrDefault(mds => mds.IsKind(SyntaxKind.ClassDeclaration))
            as ClassDeclarationSyntax;
        var innerClassConstructor =
            innerClass?.Members.FirstOrDefault(icm => icm.IsKind(SyntaxKind.ConstructorDeclaration));


        //Assert
        firstMember.Should().NotBeNull();
        firstClass.Should().NotBeNull();
        firstClass?.Modifiers.Should().Contain(st => st.IsKind(SyntaxKind.PartialKeyword));
        innerClass.Should().NotBeNull();
        innerClass?.Identifier.Text.Should().Be("Builder");
        innerClass?.Modifiers.Should().Contain(st => st.IsKind(SyntaxKind.PartialKeyword));
    }

    [Theory]
    [AutoTestParams]
    internal void GenerateEntity_Default_Immutable_GeneratesClassWithInitProperties(
        [Frozen] CodeGenConfig config, EntitiesTemplateModel model,
        TemplateService sut)
    {
        //Arrange
        config.TargetLanguageVersion = "Default";
        config.CreateImmutableEntities = true;
        GenerateSchemaMetadataStub(config, model);

        sut.LoadTemplates(config);

        //Act
        var entityContent = sut.GenerateEntity(model);
        var syntaxTree = CSharpSyntaxTree.ParseText(entityContent);
        var root = syntaxTree.GetCompilationUnitRoot();
        var namespaceDeclaration = root.Members[0] as FileScopedNamespaceDeclarationSyntax;
        var entityClass = namespaceDeclaration!.Members[0] as ClassDeclarationSyntax;
        var properties = entityClass!.Members.Where(mds => mds.IsKind(SyntaxKind.PropertyDeclaration))
            .Select(mds => mds as PropertyDeclarationSyntax).ToList();

        //Assert
        model.TabularStructure.Columns.ForEach(c =>
        {
            var prop = properties.FirstOrDefault(pds => pds.Identifier.Text == c.Name);
            prop.Should().NotBeNull("Should have a property for each column");
            prop!.AccessorList!.Accessors.Should().ContainSingle(ads => ads.IsKind(SyntaxKind.GetAccessorDeclaration), "Property should have a get accessor");
            prop!.AccessorList!.Accessors.Should().ContainSingle(ads => ads.IsKind(SyntaxKind.InitAccessorDeclaration), "Property should have an init accessor");
        });
        
    }

    [Theory]
    [AutoTestParams]
    internal void GenerateEntity_Default_ImmutableRecord_GeneratesRecordWithInitProperties(
        [Frozen] CodeGenConfig config, EntitiesTemplateModel model,
        TemplateService sut)
    {
        //Arrange
        config.TargetLanguageVersion = "Default";
        config.CreateImmutableEntities = true;
        config.CreateRecordEntities = true;
        GenerateSchemaMetadataStub(config, model);

        sut.LoadTemplates(config);

        //Act
        var entityContent = sut.GenerateEntity(model);
        var syntaxTree = CSharpSyntaxTree.ParseText(entityContent);
        var root = syntaxTree.GetCompilationUnitRoot();
        var namespaceDeclaration = root.Members[0] as FileScopedNamespaceDeclarationSyntax;
        var entityRecord = namespaceDeclaration!.Members[0] as RecordDeclarationSyntax;
        var properties = entityRecord!.Members.Where(mds => mds.IsKind(SyntaxKind.PropertyDeclaration))
            .Select(mds => mds as PropertyDeclarationSyntax).ToList();

        //Assert
        model.TabularStructure.Columns.ForEach(c =>
        {
            var prop = properties.FirstOrDefault(pds => pds.Identifier.Text == c.Name);
            prop.Should().NotBeNull("Should have a property for each column");
            prop!.AccessorList!.Accessors.Should().ContainSingle(ads => ads.IsKind(SyntaxKind.GetAccessorDeclaration), "Property should have a get accessor");
            prop!.AccessorList!.Accessors.Should().ContainSingle(ads => ads.IsKind(SyntaxKind.InitAccessorDeclaration), "Property should have an init accessor");
        });
        
    }
    
    [Theory]
    [AutoTestParams]
    internal void GenerateEntity_CSharp7_3_Immutable_UsesBuilderPattern(
        [Frozen] CodeGenConfig config, EntitiesTemplateModel model,
        TemplateService sut)
    {
        //Arrange
        config.TargetLanguageVersion = "CSharp7_3";
        config.CreateImmutableEntities = true;
        GenerateSchemaMetadataStub(config, model);

        sut.LoadTemplates(config);

        //Act
        var entityContent = sut.GenerateEntity(model);
        var syntaxTree = CSharpSyntaxTree.ParseText(entityContent);
        var root = syntaxTree.GetCompilationUnitRoot();
        var firstMember = root.Members[0] as NamespaceDeclarationSyntax;
        var firstClass = firstMember?.Members[0] as ClassDeclarationSyntax;
        var constructor = firstClass?.Members.FirstOrDefault(mds => mds.IsKind(SyntaxKind.ConstructorDeclaration))
            as ConstructorDeclarationSyntax;
        var entityProperties = firstClass?.Members.Where(mds => mds.IsKind(SyntaxKind.PropertyDeclaration))
            .Select(mds => mds as PropertyDeclarationSyntax);
        var innerClass = firstClass?
                .Members.FirstOrDefault(mds => mds.IsKind(SyntaxKind.ClassDeclaration))
            as ClassDeclarationSyntax;
        var builderMethods = innerClass!.Members.Where(mds => mds.IsKind(SyntaxKind.MethodDeclaration))
            .Select(mds => mds as MethodDeclarationSyntax).ToList();
        var mutationMethods = builderMethods.Where(bm => bm.Identifier.Text.StartsWith("With")).ToList();
        var buildMethod = builderMethods.FirstOrDefault(bm => bm.Identifier.Text == "Build");
        var innerClassConstructor =
            innerClass!.Members.FirstOrDefault(icm => icm.IsKind(SyntaxKind.ConstructorDeclaration));


        //Assert
        constructor.Should().NotBeNull("Entity class should have a constructor");
        constructor!.Modifiers.Should()
            .Contain(st => st.IsKind(SyntaxKind.PrivateKeyword), "Constructor should be private");
        innerClass.Should().NotBeNull("Entity class should have an inner class");
        innerClass!.Identifier.Text.Should().Be("Builder", "The name of the inner class must be Builder");
        innerClassConstructor.Should().NotBeNull("Inner class should have a constructor");
        innerClassConstructor?.Modifiers.Should().Contain(st => st.IsKind(SyntaxKind.PublicKeyword),
            "Inner class constructor should be public");
        buildMethod.Should().NotBeNull(); //Inner class must have a build method.
        buildMethod!.Modifiers.Should()
            .Contain(mds => mds.IsKind(SyntaxKind.PublicKeyword), "Build method should be public.");
        buildMethod!.ReturnType.Should().BeOfType<IdentifierNameSyntax>("Return type should be the name of a type");
        ((IdentifierNameSyntax) buildMethod.ReturnType)!.Identifier.Text.Should().Be(
            model.TabularStructure.Name + config.EntityNameSuffix, "Return type should be the entity.");
        foreach (var colName in model.TabularStructure.Columns.Select(c => c.Name))
        {
            var mutator = mutationMethods.FirstOrDefault(mds => mds.Identifier.Text == "With" + colName);
            mutator.Should().NotBeNull();
            ((IdentifierNameSyntax) mutator.ReturnType).Identifier.Text.Should()
                .Be("Builder", "Each mutator should be fluent.");
        }
    }

    private static void GenerateSchemaMetadataStub(CodeGenConfig config, EntitiesTemplateModel model)
    {
        config.EntityNameSuffix = "Yawn";
        model.TabularStructure.Name = "WhoCares";
        model.PathNamespace.EntitiesNamespace = "Testing.Amka";
        model.PathNamespace.PersistenceNamespace = "Testing.Damka";
        model.TabularStructure.Columns[0].Name = "Column0";
        model.TabularStructure.Columns[0].DataType = "string";
        model.TabularStructure.Columns[0].DefaultValue = null;
        model.TabularStructure.Columns[1].Name = "Column1";
        model.TabularStructure.Columns[1].DataType = "int";
        model.TabularStructure.Columns[1].DefaultValue = null;
        model.TabularStructure.Columns[2].Name = "Column2";
        model.TabularStructure.Columns[2].DataType = "DateTime";
        model.TabularStructure.Columns[2].DefaultValue = null;
    }
}