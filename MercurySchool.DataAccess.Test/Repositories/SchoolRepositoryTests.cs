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
    [Fact(DisplayName = "InsertSchoolAsyncReturnsList should return a list of schools")]
    public async Task InsertSchoolAsyncReturnsBool()
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

    [Fact(DisplayName = "GetSchoolsAsync should return a list of schools")]
    public async Task GetSchoolsAsyncReturnsList()
    {
        // Arrange
        var sut = await GetSchoolRepositoryAsync();

        // Act
        var result = await sut.GetSchoolsAsync();

        // Assert
        result.Should().NotBeNull().And.BeAssignableTo<IEnumerable<School>>();
    }

    [Fact(DisplayName = "GetSchoolAsync should return an intance of a school")]
    public async Task GetSchoolAsyncReturnsSchool()
    {
        // Arrange
        var sut = await GetSchoolRepositoryAsync();
        var id = Guid.Parse("ceb83806-4fd3-4bc8-8301-7ff523729634");

        // Act
        var result = await sut.GetSchoolAsync(id);

        // Assert
        result.Should().NotBeNull().And.BeAssignableTo<School>();
    }

    [Fact(DisplayName = "UpdateSchoolAsync should return a bool indicating success")]
    public async Task UpdateSchoolAsyncReturnsBool()
    {
        // Arrange
        var sut = await GetSchoolRepositoryAsync();
        var id = Guid.Parse("ceb83806-4fd3-4bc8-8301-7ff523729634");

        var school = new School
        {
            Description = "School has been updated",
            Id = id,
            Name = $"Test School :: {Guid.NewGuid()}",
            CreateDate = DateTime.Now,
        };

        // Act
        var result = await sut.UpdateSchoolAsync(school);

        // Assert
        result.Should().BeTrue();
    }

    private static async Task<ISchoolRepository> GetSchoolRepositoryAsync()
    {
        var options = await GetAppSettingsOptionsAsync();
        IDatabaseConnections sqlConnection = new SqlDatabaseConnection(options);

        return new SchoolRepository(sqlConnection);
    }
}