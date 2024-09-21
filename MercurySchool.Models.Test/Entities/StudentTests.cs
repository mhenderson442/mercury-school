using MercurySchool.Models.Entities;
using Xunit;

namespace MercurySchool.Models.Test.Entities;

public class StudentTests
{
    [Fact]
    public void StudentEntityHasRequiredPropertues()
    {
        // Arrange
        var sut = GetStudent();

        // Act

        // Assert
    }

    private static Student GetStudent() => new()
    {
    };
}