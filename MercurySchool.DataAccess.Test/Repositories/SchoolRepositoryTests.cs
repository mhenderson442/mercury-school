namespace MercurySchool.DataAccess.Test.Repositories;

/// <summary>
/// The SchoolRepository test class
/// </summary>
public class SchoolRepositoryTests : TestBase
{
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

    [Fact(DisplayName = "InsertSchoolAsyncReturnsList should return a bool indicating")]
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

    [Fact(DisplayName = "UpdateSchoolDescriptionAsync should return a bool indicating success")]
    public async Task UpdateSchoolDescriptionAsyncReturnsBool()
    {
        // Arrange
        var sut = await GetSchoolRepositoryAsync();
        var id = Guid.Parse("ceb83806-4fd3-4bc8-8301-7ff523729634");
        var description = "School description patch";

        // Act
        var result = await sut.UpdateSchoolDescriptionAsync(id, description);

        // Assert
        result.Should().BeTrue();
    }

    [Fact(DisplayName = "UpdateSchoolNameAsync should return a bool indicating success")]
    public async Task UpdateSchoolNameAsyncReturnsBool()
    {
        // Arrange
        var sut = await GetSchoolRepositoryAsync();
        var id = Guid.Parse("ceb83806-4fd3-4bc8-8301-7ff523729634");
        var name = "Updated via patch :: 3d6197ee-4111-";

        // Act
        var result = await sut.UpdateSchoolNameAsync(id, name);

        // Assert
        result.Should().BeTrue();
    }
}