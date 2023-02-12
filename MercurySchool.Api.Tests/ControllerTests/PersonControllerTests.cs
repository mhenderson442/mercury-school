namespace MercurySchool.Api.Tests.ControllerTests;
public class PersonControllerTests : TestClassBase
{
    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetPersonReturnListOfPersons()
    {
        // Arrange
        var mockedPersons = new List<Person>
        {
            InitMockedPerson()
        };

        var mockPersonRepository = CreateMockPersonRepository();
        mockPersonRepository.Setup(x => x.GetPersonsAsync(MockedAccountId)).ReturnsAsync(mockedPersons);

        var sut = CreatePersonController(mockPersonRepository);

        // Act
        var result = (OkObjectResult)await sut.GetAsync(MockedAccountId);

        // Assert
        mockPersonRepository.Verify(x => x.GetPersonsAsync(MockedAccountId));

        result.Should()
            .NotBeNull()
            .And.BeAssignableTo<OkObjectResult>();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetPersonsReturnNotFound()
    {
        // Arrange
        var mockPersonRepository = CreateMockPersonRepository();
        mockPersonRepository.Setup(x => x.GetPersonsAsync(MockedAccountId)).ReturnsAsync(new List<Person>());

        var sut = CreatePersonController(mockPersonRepository);

        // Act
        var result = (NotFoundObjectResult)await sut.GetAsync(MockedAccountId);

        // Assert
        mockPersonRepository.Verify(x => x.GetPersonsAsync(MockedAccountId));

        result.Should()
            .NotBeNull()
            .And.BeAssignableTo<NotFoundObjectResult>();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetPersonsReturnsBadRequest()
    {
        // Arrange
        var mockPersonRepository = CreateMockPersonRepository();
        mockPersonRepository.Setup(x => x.GetPersonsAsync(MockedAccountId)).ThrowsAsync(new NullReferenceException());

        var sut = CreatePersonController(mockPersonRepository);

        // Act
        var result = (BadRequestObjectResult)await sut.GetAsync(MockedAccountId);

        // Assert
        mockPersonRepository.Verify(x => x.GetPersonsAsync(MockedAccountId));

        result.Should()
            .NotBeNull()
            .And.BeAssignableTo<BadRequestObjectResult>();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task PostAsyncReturnsPerson()
    {
        // Arrange
        var person = InitMockedPerson();
        var responseMock = new Mock<ItemResponse<Person>>();

        var mockPersonRepository = CreateMockPersonRepository();
        mockPersonRepository.Setup(x => x.UpsertPersonItemAsync(It.IsAny<Person>())).ReturnsAsync(responseMock.Object);

        var sut = CreatePersonController(mockPersonRepository);

        // Act
        var result = (OkObjectResult)await sut.PostAsync(InitMockedPerson());

        // Assert
        mockPersonRepository.Verify(x => x.UpsertPersonItemAsync(It.IsAny<Person>()));

        result.Should()
            .NotBeNull().And
            .BeAssignableTo<OkObjectResult>();
    }

    private static Person InitMockedPerson()
    {
        var id = Guid.NewGuid().ToString();
        var firstName = "Mike";
        var lastName = "IntegrationTest";
        var accountId = "156600";

        return new Person(id, accountId, firstName, lastName);
    }

    private static PersonController CreatePersonController(Mock<IPersonRepository> mockPersonRepository) => new(mockPersonRepository.Object);
}
