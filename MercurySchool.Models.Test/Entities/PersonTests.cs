using FluentAssertions;
using MercurySchool.Models.Entities;

namespace MercurySchool.Models.Test.Entities;

public class PersonTests
{
    [Theory(DisplayName = "GetPerson entity should have required properties")]
    [InlineData(true)]
    [InlineData(false)]
    public void SchoolEntityHasRequiredProperties(bool hasNullDescription)
    {
        // Arrange
        var sut = GetPerson;

        if (hasNullDescription)
        {
            sut.Description = null;
        }

        // Act
        // Assert
        sut.Should().NotBeNull().And.BeAssignableTo<Person>();
    }

    [Fact(DisplayName = "Person's name property should be concatentation of first and last name")]
    public void SchoolNameShouldBeConcatendatedFirsAndLastNames()
    {
        // Arrange
        var sut = GetPerson;

        // Act
        var expectedName = $"{sut.FirstName} {sut.LastName}";

        // Assert
        sut.Name.Should().Be(expectedName);
    }

    private static Person GetPerson => new()
    {
        CreateDate = DateTime.UtcNow,
        Description = "Description of school",
        FirstName = "John",
        Id = Guid.NewGuid(),
        LastName = "Public",
        MiddleName = "Q",
        Name = "Name of person"
    };
}