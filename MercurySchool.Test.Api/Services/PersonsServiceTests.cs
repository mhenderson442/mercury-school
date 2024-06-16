namespace MercurySchool.Test.Api.Services;

public class PersonsServiceTests : TestBase
{
    [Fact(DisplayName = "GetPersonsAsync should return a list of type Persons")]
    public async Task GetPersonsAsyncReturnsList()
    {
        // Arrange
        await Task.Yield();

        var personRepository = InitializeMockPersonRepository();
        var sut = InitializePersonService(personRepository);

        // Act
        var result = await sut.GetPersonsAsync(null);

        // Assert
        personRepository.Verify(x => x.GetPersonsAsync(null), Times.Once());

        result.Should()
            .NotBeNull()
            .And.BeAssignableTo<IList<Person>>();
    }

    [Fact(DisplayName = "GetPersonsAsync with paremeter should return a list of type Persons")]
    public async Task GetPersonsAsyncReturnsWithParamList()
    {
        // Arrange
        var startWith = "A";

        var personRepository = InitializeMockPersonRepository();
        var sut = InitializePersonService(personRepository);

        // Act
        var result = await sut.GetPersonsAsync(startWith);

        // Assert
        personRepository.Verify(x => x.GetPersonsAsync(It.IsAny<string>()), Times.Once());

        result.Should()
            .NotBeNull()
            .And.BeAssignableTo<IList<Person>>();
    }

    [Fact(DisplayName = "PostPersonsAsync should return a boolean indicating success")]
    public async Task PostPersonsAsyncReturnsBool()
    {
        // Arrange
        var personRepository = InitializeMockPersonRepository();
        var sut = InitializePersonService(personRepository);

        // Act
        var result = await sut.PostPersonsAsync(It.IsAny<Person>());

        // Assert
        personRepository.Verify(x => x.PostPersonsAsync(It.IsAny<Person>()), Times.Once());

        result.Should().BeTrue();
    }

    [Fact(DisplayName = "PutPersonsAsync should return a boolean indicating success")]
    public async Task PutPersonsAsyncReturnsBool()
    {
        // Arrange
        var personRepository = InitializeMockPersonRepository();
        var sut = InitializePersonService(personRepository);

        // Act
        var result = await sut.PutPersonsAsync(It.IsAny<Person>());

        // Assert
        personRepository.Verify(x => x.PutPersonsAsync(It.IsAny<Person>()), Times.Once());

        result.Should().BeTrue();
    }

    [Fact(DisplayName = "PatchPersonsAsync should return a boolean indicating success")]
    public async Task PatchPersonsAsyncReturnsBool()
    {
        // Arrange
        var personRepository = InitializeMockPersonRepository();
        var sut = InitializePersonService(personRepository);

        var id = Guid.NewGuid().ToString();
        var patchRequest = new PatchRequest<string> { Id = Guid.NewGuid(), PropertyName = id, PropertyValue = "Test Patch" };

        var patchRequestSerialized = JsonSerializer.Serialize(patchRequest);
        var buffer = Encoding.UTF8.GetBytes(patchRequestSerialized);

        using var stream = new MemoryStream(buffer);

        // Act
        var result = await sut.PatchPersonsAsync(It.IsAny<string>(), stream);

        // Assert
        personRepository.Verify(x => x.PatchPersonsAsync(It.IsAny<PatchRequest<string>>()), Times.Once());

        result.Should().BeTrue();
    }

    [Fact(DisplayName = "DeletePersonsAsync should return a boolean indicating success")]
    public async Task DeletePersonsAsyncReturnsBool()
    {
        // Arrange
        var personRepository = InitializeMockPersonRepository();
        var sut = InitializePersonService(personRepository);

        // Act
        var result = await sut.DeletePersonsAsync(It.IsAny<string>());

        // Assert
        personRepository.Verify(x => x.DeletePersonsAsync(It.IsAny<string>()), Times.Once());

        result.Should().BeTrue();
    }

    private static Mock<IPersonsRepository> InitializeMockPersonRepository()
    {
        var personsRespository = new Mock<IPersonsRepository>();
        personsRespository.Setup(x => x.GetPersonsAsync(null)).ReturnsAsync([]);
        personsRespository.Setup(x => x.GetPersonsAsync(It.IsAny<string>())).ReturnsAsync([]);
        personsRespository.Setup(x => x.PostPersonsAsync(It.IsAny<Person>())).ReturnsAsync(true);
        personsRespository.Setup(x => x.PutPersonsAsync(It.IsAny<Person>())).ReturnsAsync(true);
        personsRespository.Setup(x => x.PatchPersonsAsync(It.IsAny<PatchRequest<string>>())).ReturnsAsync(true);
        personsRespository.Setup(x => x.DeletePersonsAsync(It.IsAny<string>())).ReturnsAsync(true);

        return personsRespository;
    }

    private static PersonsService InitializePersonService(Mock<IPersonsRepository> personsRepository)
    {
        var logger = new NullLogger<PersonsService>();
        return new PersonsService(logger, personsRepository.Object);
    }
}