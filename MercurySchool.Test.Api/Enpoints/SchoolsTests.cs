namespace MercurySchool.Test.Api.Enpoints;

public class SchoolsTests(WebApplicationFactoryMock<Program> webApplicationFactoryMock) : EndpointTestBase(webApplicationFactoryMock), IClassFixture<WebApplicationFactoryMock<Program>>
{
    [Fact]
    public async Task GetAsyncShouldReturnOk()
    {
        // Arrange
        using var client = _webApplicationFactoryMock.CreateClient();

        // Act
        var result = await client.GetAsync("/api/schools");

        // Assert
        result.Should().BeSuccessful();
        result.Content.Should().BeAssignableTo<StreamContent>();

        var options = GetJsonSerializerOptions();

        var contentStream = await result.Content.ReadAsStringAsync();
        var contentResult = JsonSerializer.Deserialize<List<School>>(contentStream, options);

        contentResult.Should()
            .NotBeNull()
            .And.BeAssignableTo<List<School>>();
    }

    [Fact]
    public async Task GetAsyncWithIDShouldReturnOk()
    {
        // Arrange
        var id = Guid.NewGuid().ToString();

        using var client = _webApplicationFactoryMock.CreateClient();

        // Act
        var result = await client.GetAsync($"/api/schools/{id}");
        result.Should().BeSuccessful();
        result.Content.Should().BeAssignableTo<StreamContent>();

        var options = GetJsonSerializerOptions();
        var contentStream = await result.Content.ReadAsStringAsync();
        var contentResult = JsonSerializer.Deserialize<School>(contentStream, options);

        // Assert
        contentResult.Should()
            .NotBeNull()
            .And.BeAssignableTo<School>();
    }

    [Fact]
    public async Task PatchAsyncSchoolShouldReturnCreated()
    {
        // Arrange
        var id = Guid.NewGuid();
        var patchItem = new { Name = Guid.NewGuid().ToString() };

        var stringContent = new StringContent(JsonSerializer.Serialize(patchItem));

        using var client = _webApplicationFactoryMock.CreateClient();

        // Act
        var result = await client.PatchAsync($"/api/schools/{id}", stringContent);

        // Assert
        result.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task PostAsyncSchooolShouldReturnCreated()
    {
        // Arrange
        var id = Guid.NewGuid();
        var school = new School { Id = id, Name = Guid.NewGuid().ToString() };

        using var client = _webApplicationFactoryMock.CreateClient();

        // Act
        var result = await client.PostAsJsonAsync($"/api/schools", school);

        // Assert
        result.Should().BeSuccessful();
    }
}