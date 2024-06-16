namespace MercurySchool.Test.DataAccess.RepositoryTests;

public class PersonsRepositoryTests : TestBase
{
    [Fact(DisplayName = "GetPersonsAsync should return a person")]
    public async Task GetSchoolAsyncShouldReturnSchool()
    {
        // Arrange
        var sut = InitializePersonsRepository();

        // Act
        var result = await sut.GetPersonsAsync();

        // Assert
        result.Should().BeAssignableTo<List<Person?>>();
    }

    private static PersonsRepository InitializePersonsRepository()
    {
        var sqlConnectionFactory = InitializeSqlConnectionFactory();
        return new PersonsRepository(sqlConnectionFactory);
    }

    private Guid TestPersonId => Guid.Parse("7A316983-1619-4A05-91E1-561533B6E18A");
}