namespace MercurySchool.Api.Tests.RepositoryTests;
public class PersonRepositoryTests : TestClassBase
{
    private readonly string _accountId = "156600";


    [Fact]
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

    [Theory]
    [InlineData("8abeae0a-21ef-48b7-b7f3-8afac6fe5c3e")]
    [InlineData(null)]
    [Trait("Category", "Integration")]
    public async Task UpsertPersonItemShouldReturnItem(string? id)
    {

        // Arrange
        id ??= Guid.NewGuid().ToString();
        var accountId = "156600";
        var firstName = "Mike";
        var lastName = "IntegrationTest";
        var middleName = "Q";

        var person = new Person(accountId){Id = id, FirstName = firstName, MiddleName = middleName, LastName = lastName};
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
