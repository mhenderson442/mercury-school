namespace MercurySchool.Test.DataAccess.RepositoryTests;

public class SchoolRepositoryTests : TestBase
{
    [Fact(DisplayName = "GetSchoolsAsync should return a school")]
    public async Task GetSchoolAsyncShouldReturnSchool()
    {
        // Arrange
        var id = Guid.Parse("bc72d9c6-34a7-4291-8414-961a033bc4e9");
        var sut = InitializeSchoolRepository();

        // Act
        var result = await sut.GetSchoolsAsync(id);

        // Assert
        result.Should().BeAssignableTo<School?>();
    }

    [Fact(DisplayName = "GetSchoolsAsync should return a list of schools")]
    public async Task GetSchoolsAsyncShouldReturnList()
    {
        // Arrange
        var sut = InitializeSchoolRepository();

        // Act
        var result = await sut.GetSchoolsAsync();

        // Assert
        result.Should().BeAssignableTo<IList<School>>();
        result.Count.Should().BeGreaterThan(0);
    }

    [Theory(DisplayName = "PatchSchoolsAsync should return a bool")]
    [InlineData("Name")]
    [InlineData("Description")]
    public async Task PatchSchoolAsyncREturnsBool(string propertyName)
    {
        // Arrange
        var sut = InitializeSchoolRepository();

        var patchRequest = new PatchRequest<string>
        {
            Id = Guid.Parse("bc72d9c6-34a7-4291-8414-961a033bc4e9"),
            PropertyName = propertyName,
            PropertyValue = $"Integration Test: UPDATE {propertyName}"
        };

        // Act
        var result = await sut.PatchSchoolsAsync(patchRequest);

        // Assert
        result.Should().BeTrue();
    }

    [Theory(DisplayName = "PostSchoolsAsync should return a bool")]
    [InlineData("Description Test School")]
    [InlineData(null)]
    public async Task PostSchoolAsyncReturnsBool(string? description)
    {
        // Arrange
        var sut = InitializeSchoolRepository();
        var school = new School
        {
            Id = Guid.NewGuid(),
            Name = "Integration Test School",
            Description = description
        };

        // Act
        var result = await sut.PostSchoolsAsync(school);

        // Assert
        result.Should().BeTrue();
    }

    private static SchoolsRepository InitializeSchoolRepository()
    {
        var sqlConnectionFactory = InitializeSqlConnectionFactory();
        return new SchoolsRepository(sqlConnectionFactory);
    }
}