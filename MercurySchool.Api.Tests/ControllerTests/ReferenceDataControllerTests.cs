namespace MercurySchool.Api.Tests.ControllerTests;
public class ReferenceDataControllerTests : TestClassBase
{

    [Fact(DisplayName = "Given a type, GetAsync returns an OK result")]
    [Trait("Category", "Unit")]
    public async Task GetReferenceDataByType_ShouldReturnOkResult()
    {
        // Arrange
        var mockedReferenceData = new List<string> { "Unit Test" };

        var mockReferenceDataRepository = CreateMockReferenceDataRepository();
        mockReferenceDataRepository.Setup(x => x.GetReferenceDataAsync(Constants.ReferenceDataTypes.AcademicStatus)).ReturnsAsync(mockedReferenceData);

        var sut = CreateReferenceDataController(mockReferenceDataRepository);

        // Act
        var result = (OkObjectResult)await sut.GetAsync(Constants.ReferenceDataTypes.AcademicStatus);

        // Assert
        mockReferenceDataRepository.Verify(x => x.GetReferenceDataAsync(Constants.ReferenceDataTypes.AcademicStatus));

        result.Should().BeAssignableTo<IActionResult>();
        result?.Value.Should().BeAssignableTo<List<string>>();
    }

    [Fact(DisplayName = "Given a type is null, GetAsync returns an OK result")]
    [Trait("Category", "Unit")]
    public async Task GetPersonsReturnNotFound()
    {
        // Arrange
        var mockedReferenceData = new List<string>();

        var mockReferenceDataRepository = CreateMockReferenceDataRepository();
        mockReferenceDataRepository.Setup(x => x.GetReferenceDataAsync(Constants.ReferenceDataTypes.AcademicStatus)).ReturnsAsync(mockedReferenceData);

        var sut = CreateReferenceDataController(mockReferenceDataRepository);

        // Act
        var result = (NotFoundObjectResult)await sut.GetAsync(Constants.ReferenceDataTypes.AcademicStatus);

        // Assert
        mockReferenceDataRepository.Verify(x => x.GetReferenceDataAsync(Constants.ReferenceDataTypes.AcademicStatus));

        result.Should()
            .NotBeNull()
            .And.BeAssignableTo<NotFoundObjectResult>();
    }

    [Fact(DisplayName = "Get Reference Data Returns Bad Request")]
    [Trait("Category", "Unit")]
    public async Task GetPersonsReturnsBadRequst()
    {
        // Arrange
        var mockReferenceDataRepository = CreateMockReferenceDataRepository();
        mockReferenceDataRepository.Setup(x => x.GetReferenceDataAsync(Constants.ReferenceDataTypes.AcademicStatus)).ThrowsAsync(new NullReferenceException());

        var sut = CreateReferenceDataController(mockReferenceDataRepository);
        // Act
        var result = (BadRequestObjectResult)await sut.GetAsync(Constants.ReferenceDataTypes.AcademicStatus);

        // Assert
        mockReferenceDataRepository.Verify(x => x.GetReferenceDataAsync(Constants.ReferenceDataTypes.AcademicStatus));

        result.Should()
            .NotBeNull()
            .And.BeAssignableTo<BadRequestObjectResult>();
    }


    private static ReferenceDataController CreateReferenceDataController(Mock<IReferenceDataRepository> mockReferenceDataRepository) => new(mockReferenceDataRepository.Object);
}
