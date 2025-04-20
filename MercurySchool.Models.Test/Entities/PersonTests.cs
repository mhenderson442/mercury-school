namespace MercurySchool.Models.Test.Entities;

public class PersonTests : TestBase
{
    [Theory(DisplayName = "GetTestPerson entity should have required properties")]
    [InlineData(true)]
    [InlineData(false)]
    public void PersonEntityHasRequiredProperties(bool hasNullDescription)
    {
        // Arrange
        var sut = GetTestPerson();

        if (hasNullDescription)
        {
            sut.Description = null;
        }

        // Act
        // Assert
        sut.Should().NotBeNull().And.BeAssignableTo<Person>();
    }

    [Fact(DisplayName = "Person's name property should be concatentation of first and last name")]
    public void PersonNameShouldBeConcatendatedFirsAndLastNames()
    {
        // Arrange
        var sut = GetTestPerson();

        // Act
        var expectedName = $"{sut.FirstName} {sut.LastName}";

        // Assert
        sut.Name.Should().Be(expectedName);
    }

    // TODO: Add person patch functions
    // TODO: Add person delete functions
}