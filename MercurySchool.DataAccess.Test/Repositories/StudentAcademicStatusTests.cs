using FluentAssertions;
using MercurySchool.Models.Entities;

namespace MercurySchool.DataAccess.Test.Repositories;

public class StudentAcademicStatusTests : TestBase
{
    [Fact(DisplayName = "GetStudentAcademicStatuses shoud return a list of type StudentAcademicStatus")]
    public async Task GetStudentAcademicStatusReturnsList()
    {
        // Arrange
        var sut = await GetStudentAcademicStatusRepositoryAsync();

        // Act
        var result = await sut.GetStudentAcademicStatuses();

        // Assert
        result.Should().NotBeEmpty()
            .And.BeAssignableTo<IEnumerable<StudentAcademicStatus>>();
    }
}