using FluentAssertions;
using MercurySchool.Models.Entities;

namespace MercurySchool.DataAccess.Test.Repositories;

public class StudentRepositoryTests : TestBase
{
    [Fact(DisplayName = "InsertStudentAsyncReturns should return a bool indicateing success")]
    public async Task InsertPersonAsyncReturnsBool()
    {
        // Arrange
        var sut = await GetStudentRepositoryAsync();

        var student = GetStudent();
        student.Person.Id = Guid.Parse("c78ca432-23eb-44ba-b3d4-5d3dec2e9a3a");

        // Act
        var result = await sut.InsertStudentAsync(student);

        // Assert
        result.Should().BeTrue();
    }

    [Theory(DisplayName = "GetStudentsReturnsList should return a paginated list of students")]
    [InlineData("P")]
    [InlineData("Q")]
    [InlineData(null)]
    public async Task GetStudentsAsyncReturnsList(string? lastNameStartsWith)
    {
        // Arrange
        var sut = await GetStudentRepositoryAsync();
        var pageNumber = 1;
        var pageSize = 25;

        // Act
        var result = await sut.GetStudentRepositoryAsync(pageNumber, pageSize, lastNameStartsWith);

        // Assert
        result.Should().NotBeNull()
            .And.BeAssignableTo<IEnumerable<Student>>()
            .And.HaveCountGreaterThanOrEqualTo(0)
            .And.HaveCountLessThanOrEqualTo(pageSize);
    }
}