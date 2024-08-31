using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ArchitectureTests;

public class ArchitectureTests
{
    private const string DomainNamespace = "Domain";
    private const string ApplicationNamespace = "Application";
    private const string InfrastructureNamespace = "Infrastructure";
    private const string PersistenceNamespace = "Persistence";
    private const string PresentationNamespace = "Presenttation";

    private const string APINamespace = "API";


    // Use this naming convension
    // .._Should_[Not]_...()
    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        #region Arrange
        var assembly = Domain.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PersistenceNamespace,
            PresentationNamespace,

            APINamespace
        };
        #endregion

        #region Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();
        #endregion

        #region Assert
        testResult.IsSuccessful.Should().BeTrue();
        #endregion
    }


    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        #region Arrange
        var assembly = Application.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PersistenceNamespace,
            PresentationNamespace,

            APINamespace
        };
        #endregion

        #region Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();
        #endregion

        #region Assert
        testResult.IsSuccessful.Should().BeTrue();
        #endregion
    }


    [Fact]
    public void Persistence_Should_Not_HaveDependencyOnPresentation()
    {
        #region Arrange
        var assembly = Persistence.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PresentationNamespace,

            APINamespace
        };
        #endregion

        #region Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();
        #endregion

        #region Assert
        testResult.IsSuccessful.Should().BeTrue();
        #endregion
    }


    [Fact]
    public void Presentation_Should_Not_HaveDependencyOnInfrastructure()
    {
        #region Arrange
        var assembly = Presentation.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PersistenceNamespace,

            APINamespace
        };
        #endregion

        #region Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();
        #endregion

        #region Assert
        testResult.IsSuccessful.Should().BeTrue();
        #endregion
    }


}

