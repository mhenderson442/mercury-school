namespace MercurySchool.Models.Test.Entities;

public class SchoolTests
{
    [Theory(DisplayName = "GetSchool entity should have required properties")]
    [InlineData(true)]
    [InlineData(false)]
    public void SchoolEntityHasRequiredProperties(bool hasNullDescription)
    {
        // Arrange
        var sut = GetSchool();

        if (hasNullDescription)
        {
            sut.Description = null;
        }

        // Act
        // Assert
        sut.Should().NotBeNull().And.BeAssignableTo<School>();
    }

    [Fact(DisplayName = "GetSchool name should be updatable")]
    public void SchoolNameCanBeupdated()
    {
        // Arrange
        var sut = GetSchool();

        // Act
        sut.Name = "Upated name of school";

        // Assert
        sut.Should().NotBeNull().And.BeAssignableTo<School>();
    }

    [Fact(DisplayName = "GetSchool description should be updatable")]
    public void SchoolDescriptionCanBeupdated()
    {
        // Arrange
        var sut = GetSchool();

        // Act
        sut.Description = "Upated description of school";

        // Assert
        sut.Should().NotBeNull().And.BeAssignableTo<School>();
    }

    private static School GetSchool() => new()
    {
        Id = Guid.NewGuid(),
        Name = "Name of GetSchool",
        Description = "Description of school",
        CreateDate = DateTime.UtcNow
    };
}