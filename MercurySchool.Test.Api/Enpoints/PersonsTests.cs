using System.Xml.XPath;

namespace MercurySchool.Test.Api.Enpoints;

public class PersonsTests(WebApplicationFactoryMock<Program> webApplicationFactoryMock) : EndpointTestBase(webApplicationFactoryMock), IClassFixture<WebApplicationFactoryMock<Program>>
{
    [Fact]
    public async Task GetAsyncShouldReturnOk()
    {
        // Arrange
        using var client = _webApplicationFactoryMock.CreateClient();

        // Act
        var result = await client.GetAsync("/api/persons");

        // Assert
        result.Should().BeSuccessful();
        result.Content.Should().BeAssignableTo<StreamContent>();

        var options = GetJsonSerializerOptions();

        var contentStream = await result.Content.ReadAsStringAsync();
        var contentResult = JsonSerializer.Deserialize<List<Person>>(contentStream, options);

        contentResult.Should()
            .NotBeNull()
            .And.BeAssignableTo<List<Person>>();
    }

    [Theory]
    [InlineData("A")]
    [InlineData("B")]
    [InlineData("C")]
    [InlineData("D")]
    public async Task GetAsyncWithParameterShouldReturnOk(string startsWithValue)
    {
        // Arrange
        using var client = _webApplicationFactoryMock.CreateClient();

        // Act
        var result = await client.GetAsync($"/api/persons/{startsWithValue}");

        // Assert
        result.Should().BeSuccessful();
        result.Content.Should().BeAssignableTo<StreamContent>();

        var options = GetJsonSerializerOptions();

        var contentStream = await result.Content.ReadAsStringAsync();
        var contentResult = JsonSerializer.Deserialize<List<Person>>(contentStream, options);

        contentResult.Should()
            .NotBeNull()
            .And.BeAssignableTo<List<Person>>();
    }

    [Fact]
    public async Task PostAsyncWithParameterShouldReturnAccepted()
    {
        // Arrange
        using var client = _webApplicationFactoryMock.CreateClient();

        var person = InitializeMockPerson();

        // Act
        var result = await client.PostAsJsonAsync($"/api/persons", person);

        // Assert
        result.Should().BeSuccessful();
    }

    [Fact]
    public async Task PutsyncWithParameterShouldReturnAccepted()
    {
        // Arrange
        using var client = _webApplicationFactoryMock.CreateClient();

        var person = InitializeMockPerson();

        // Act
        var result = await client.PutAsJsonAsync($"/api/persons", person);

        // Assert
        result.Should().BeSuccessful();
    }

    [Fact]
    public async Task PatchAsyncWithParameterShouldReturnAccepted()
    {
        // Arrange
        using var client = _webApplicationFactoryMock.CreateClient();

        var id = Guid.NewGuid();

        var patchItem = new PatchRequest<string>()
        {
            Id = id,
            PropertyName = "Test Property Name",
            PropertyValue = "Test Property Value"
        };

        var stringContent = new StringContent(JsonSerializer.Serialize(patchItem));

        // Act
        var result = await client.PatchAsync($"/api/persons/{id}", stringContent);

        // Assert
        result.Should().BeSuccessful();
    }

    [Fact]
    public async Task DeleteAsyncWithParameterShouldReturnAccepted()
    {
        // Arrange
        using var client = _webApplicationFactoryMock.CreateClient();
        var id = Guid.NewGuid();

        // Act
        var result = await client.DeleteAsync($"/api/persons/{id}");

        // Assert
        result.Should().BeSuccessful();
    }

    private static Person InitializeMockPerson() => new() { FirstName = "John", Id = Guid.NewGuid(), LastName = "Public", MiddleName = "Q" };
}