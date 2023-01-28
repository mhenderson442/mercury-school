namespace MercurySchool.Api.Tests.RepositoryTests;
public class PersonRepositoryTests : TestClassBase
{
    private readonly string _accountId = "156600";


    [Fact(DisplayName = "Get Persons Should Return List")]
    [Trait("Category", "Integration")]
    public async Task GetPersonsShouldReturnList()
    {

        // Arrange
        IPersonRepository sut = CreatePersonRepository();

        // Act
        var result = await sut.GetPersonsAsync(_accountId);

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IList<Person>>(result);

    }

    [Theory(DisplayName = "UpsertPersonItemAsync Should Return Item")]
    [InlineData("8abeae0a-21ef-48b7-b7f3-8afac6fe5c3e")]
    [InlineData(null)]
    [Trait("Category", "Integration")]
    public async Task UpsertPersonItemShouldReturnItem(string? id)
    {

        // Arrange
        id ??= Guid.NewGuid().ToString();
        var firstName = "Mike";
        var lastName = "IntegrationTest";

        var person = new Person(id, _accountId, firstName, lastName);
        IPersonRepository sut = CreatePersonRepository();

        // Act
        var result = await sut.UpsertPersonItemAsync(person);

        // Assert
        result.Should().NotBeNull().And.BeAssignableTo<ItemResponse<Person>>();

    }

    private static IPersonRepository CreatePersonRepository()
    {
        var databaseAccessFactory = CreateDataAccessFactory();
        IPersonRepository personRepository = new PersonRepository(databaseAccessFactory);
        return personRepository;
    }
}
