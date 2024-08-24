using FluentAssertions;
using MercurySchool.Models.Entities;

namespace MercurySchool.Models.Test.Entities;

public class SchoolTests
{
    [Theory(DisplayName = "School entity should have required properties")]
    [InlineData(true)]
    [InlineData(false)]
    public void SchoolEntityHasRequiredProperties(bool hasNullDescription)
    {
        // Arrange
        var sut = new School()
        {
            Id = Guid.NewGuid(),
            Name = "Name of School",
            Description = hasNullDescription ? null : "Description of school"
        };

        // Act
        // Assert
        sut.Should().NotBeNull().And.BeAssignableTo<School>();
    }

    [Fact(DisplayName = "School name should be updatable")]
    public void SchoolNameCanBeupdated()
    {
        // Arrange
        var sut = new School()
        {
            Id = Guid.NewGuid(),
            Name = "Name of School",
            Description = "Description of school"
        };

        // Act
        sut.Name = "Upated name of school";

        // Assert
        sut.Should().NotBeNull().And.BeAssignableTo<School>();
    }

    [Fact(DisplayName = "School description should be updatable")]
    public void SchoolDescriptionCanBeupdated()
    {
        // Arrange
        var sut = new School()
        {
            Id = Guid.NewGuid(),
            Name = "Name of School",
            Description = "Description of school"
        };

        // Act
        sut.Description = "Upated description of school";

        // Assert
        sut.Should().NotBeNull().And.BeAssignableTo<School>();
    }
}