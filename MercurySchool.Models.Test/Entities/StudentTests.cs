namespace MercurySchool.Models.Test.Entities;

public class StudentTests : TestBase
{
    [Fact]
    public void StudentEntityHasRequiredPropertues()
    {
        // Arrange
        var sut = GetTestStudent();

        // Act
        // Assert
        sut.StudentAcademicStatus.Should().NotBeNull();
    }
}