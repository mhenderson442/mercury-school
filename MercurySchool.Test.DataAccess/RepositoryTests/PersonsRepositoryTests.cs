namespace MercurySchool.Test.DataAccess.RepositoryTests;

public class PersonsRepositoryTests : TestBase
{
    [Fact(DisplayName = "GetPersonsAsync should return a person")]
    public async Task GetPersonsAsyncShouldReturnPersons()
    {
        // Arrange
        var sut = InitializePersonsRepository();

        // Act
        var result = await sut.GetPersonsAsync();

        // Assert
        result.Should().BeAssignableTo<List<Person?>>();
    }

    [Fact(DisplayName = "GetPersonsAsync with parameter should return a person")]
    public async Task GetPersonsAsyncWithParameterShouldReturnPersons()
    {
        // Arrange
        var startsWith = "A";
        var sut = InitializePersonsRepository();

        // Act
        var result = await sut.GetPersonsAsync(startsWith);

        // Assert
        result.Should().BeAssignableTo<List<Person?>>();
    }

    [Theory(DisplayName = "PatchPersonsAsync should return value indicating success")]
    [InlineData("FirstName", "Juan")]
    [InlineData("MiddleName", "Q2")]
    [InlineData("LastName", "Publica")]
    public async Task PatchPersonsReturnsBool(string propertyName, string propertyValue)
    {
        // Arrange
        var patchRequest = new PatchRequest<string>
        {
            Id = TestPersonId,
            PropertyName = propertyName,
            PropertyValue = propertyValue,
        };

        var sut = InitializePersonsRepository();

        // Act
        var result = await sut.PatchPersonsAsync(patchRequest);

        // Assert
        result.Should().BeTrue();
    }

    [Theory(DisplayName = "PostPersonsAsync should return a value indicating success")]
    [InlineData("Integration", "Tester", "Q")]
    [InlineData("Integration2", "Tester2", null)]
    public async Task PostPersonsReturnsBool(string firstName, string lastName, string? midellName)
    {
        // Arrange
        var person = new Person
        {
            FirstName = firstName,
            Id = Guid.NewGuid(),
            LastName = lastName,
            MiddleName = midellName
        };

        var sut = InitializePersonsRepository();

        // Act
        var result = await sut.PostPersonsAsync(person);

        // Assert
        result.Should().BeTrue();
    }

    [Theory(DisplayName = "PutPersonsAsync should return a value indicating success")]
    [InlineData("Integration", "Tester", "Q", "4e05dc8b-75dd-428e-be88-23bc9ff29134")]
    [InlineData("Integration2", "Tester2", null, "5cfa0a3c-ce7f-425f-859a-fbcd4a6f13fe")]
    public async Task PutPersonsReturnsBool(string firstName, string lastName, string? midellName, string id)
    {
        // Arrange
        var person = new Person
        {
            FirstName = firstName,
            Id = Guid.Parse(id),
            LastName = lastName,
            MiddleName = midellName
        };

        var sut = InitializePersonsRepository();

        // Act
        var result = await sut.PutPersonsAsync(person);

        // Assert
        result.Should().BeTrue();
    }

    private static PersonsRepository InitializePersonsRepository()
    {
        var sqlConnectionFactory = InitializeSqlConnectionFactory();
        return new PersonsRepository(sqlConnectionFactory);
    }

    private static Guid TestPersonId => Guid.Parse("701bf36d-6874-4a99-a9f6-602fb76184bb");
}