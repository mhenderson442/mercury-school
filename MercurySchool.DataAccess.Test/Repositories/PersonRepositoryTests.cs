using FluentAssertions;
using MercurySchool.DataAccess.Connections;
using MercurySchool.DataAccess.Repositories;
using MercurySchool.Models.Entities;

namespace MercurySchool.DataAccess.Test.Repositories;

public class PersonRepositoryTests : TestBase
{
    [Theory(DisplayName = "GetPersonsReturnsList should return a paginated list of persons")]
    [InlineData("P")]
    [InlineData("Q")]
    [InlineData(null)]
    public async Task GetPersonsAsyncReturnsBool(string? lastNameStartsWith)
    {
        // Arrange
        var sut = await GetPersonRepositoryAsync();
        var pageNumber = 1;
        var pageSize = 25;

        // Act
        var result = await sut.GetPersons(pageNumber, pageSize, lastNameStartsWith);

        // Assert
        result.Should().NotBeNull()
            .And.BeAssignableTo<IEnumerable<Person>>()
            .And.HaveCountGreaterThanOrEqualTo(0)
            .And.HaveCountLessThanOrEqualTo(pageSize);
    }

    [Fact(DisplayName = "InsertPersonAsyncReturns should return a bool indicateing success")]
    public async Task InsertPersonAsyncReturnsBool()
    {
        // Arrange
        var sut = await GetPersonRepositoryAsync();

        var person = GetPerson();

        // Act
        var result = await sut.InsertSchoolAsync(person);

        // Assert
        result.Should().BeTrue();
    }

    [Fact(DisplayName = "UpdateSchoolAsync should return a bool indicateing success")]
    public async Task UpdatePersonAsyncReturnsBool()
    {
        // Arrange
        var sut = await GetPersonRepositoryAsync();

        var person = GetPerson();
        person.Id = Guid.Parse("78244c6a-a34f-4568-ae65-aa7596f48bd7");
        person.FirstName = "John (updated)";
        person.MiddleName = "Q (updated)";
        person.LastName = "Public (updated)";

        // Act
        var result = await sut.UpdateSchoolAsync(person);

        // Assert
        result.Should().BeTrue();
    }
}