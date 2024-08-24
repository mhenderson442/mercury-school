using FluentAssertions;
using MercurySchool.DataAccess.Connections;
using MercurySchool.DataAccess.Repositories;
using MercurySchool.Models.Entities;
using Microsoft.Identity.Client;

namespace MercurySchool.DataAccess.Test.Repositories;

/// <summary>
/// The SchoolRepository test class
/// </summary>
public class SchoolRepositoryTests : TestBase
{
    [Fact(DisplayName = "nsertSchoolAsync should return a list of schools")]
    public async Task InsertSchoolAsyncReturnsList()
    {
        // Arrange
        var sut = await GetSchoolRepositoryAsync();

        var school = new School
        {
            Description = "Test Description",
            Id = Guid.NewGuid(),
            Name = $"Test School :: {Guid.NewGuid()}",
            CreateDate = DateTime.Now,
        };

        // Act
        var result = await sut.InsertSchoolAsync(school);

        // Assert
        result.Should().BeTrue();
    }

    [Fact(DisplayName = "InsertSchoolAsync should return a list of schools")]
    public async Task GetShcoolAsyncReturnsList()
    {
        // Arrange
        var sut = await GetSchoolRepositoryAsync();

        // Act
        var result = await sut.GetSchoolAsync();

        // Assert
        result.Should().NotBeNull().And.BeAssignableTo<IEnumerable<School>>();
    }

    private static async Task<ISchoolRepository> GetSchoolRepositoryAsync()
    {
        var options = await GetAppSettingsOptionsAsync();
        IDatabaseConnections sqlConnection = new SqlDatabaseConnection(options);

        return new SchoolRepository(sqlConnection);
    }
}