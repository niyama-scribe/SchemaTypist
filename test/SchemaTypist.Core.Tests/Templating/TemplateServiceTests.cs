using System;
using System.Linq;
using AutoFixture;
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
    [Theory, AutoTestParams]
    internal void GenerateEntities_WithoutLoadingTemplates_ThrowsInvalidOperationException(
        EntitiesTemplateModel model,
        TemplateService sut)
    {
        //Arrange
        
        //Act
        sut.Invoking(ts => ts.GenerateEntity(model)).Should().Throw<InvalidOperationException>();
        
        //Assert
    }
    
    [Theory, AutoTestParams]
    internal void GeneratePersistence_WithoutLoadingTemplates_ThrowsInvalidOperationException(
        PersistenceTemplateModel model,
        TemplateService sut)
    {
        //Arrange
        
        //Act
        sut.Invoking(ts => ts.GeneratePersistence(model)).Should().Throw<InvalidOperationException>();
        
        //Assert
    }
    
    [Theory, AutoTestParams]
    internal void GenerateDapperMapper_WithoutLoadingTemplates_ThrowsInvalidOperationException(
        DapperInitialiserTemplateModel model,
        TemplateService sut)
    {
        //Arrange
        
        //Act
        sut.Invoking(ts => ts.GenerateDapperMapper(model)).Should().Throw<InvalidOperationException>();
        
        //Assert
    }

    [Theory, AutoTestParams]
    internal void GenerateEntity_CSharp7_3_Immutable_GeneratesBuilder(
        [Frozen] CodeGenConfig config, EntitiesTemplateModel model,
        TemplateService sut)
    {
        //Arrange
        config.TargetLanguageVersion = "CSharp7_3";
        config.CreateImmutableEntities = true;
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

        sut.LoadTemplates(config);
        
        //Act
        var entityContent = sut.GenerateEntity(model);
        var syntaxTree = CSharpSyntaxTree.ParseText(entityContent);
        var root = syntaxTree.GetCompilationUnitRoot();
        var firstMember = root.Members[0] as NamespaceDeclarationSyntax;
        var firstClass = firstMember?.Members[0] as ClassDeclarationSyntax;
        var constructor = firstClass.Members.FirstOrDefault(mds => mds.Kind() == SyntaxKind.ConstructorDeclaration)
            as ConstructorDeclarationSyntax;
        var innerClass = firstClass?
            .Members.FirstOrDefault(mds => mds.Kind() == SyntaxKind.ClassDeclaration)
            as ClassDeclarationSyntax;
        
        
        //Assert
        firstMember.Should().NotBeNull();
        firstClass.Should().NotBeNull();
        constructor.Should().NotBeNull();
        constructor?.Modifiers.Any(st => st.Kind() == SyntaxKind.PrivateKeyword);
        innerClass.Should().NotBeNull();
        innerClass.Identifier.Text.Should().Be("Builder");
        

    }
    
    
}