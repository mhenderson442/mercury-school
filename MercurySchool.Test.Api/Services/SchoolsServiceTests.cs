namespace MercurySchool.Test.Api.Services;

public class SchoolsServiceTests
{
    private static readonly School SchoolMock = new() { Id = Guid.NewGuid(), Name = Guid.NewGuid().ToString() };

    [Fact(DisplayName = "GetSchoolsAsync should return a school")]
    public async Task GetSchoolAsyncShouldReturnSchool()
    {
        // Arrange
        var schoolsRepository = InitializeMockSchoolRepository();
        var sut = InitializeSchoolsService(schoolsRepository);

        // Act
        var result = await sut.GetSchoolAsync(TestBase.SchoolId);

        // Assert
        schoolsRepository.Verify(x => x.GetSchoolsAsync(Guid.Parse(TestBase.SchoolId)), Times.Once());
        result.Should().BeAssignableTo<School>();
    }

    [Fact(DisplayName = "GetSchoolsAsync should return a list of schools")]
    public async Task GetSchoolsAsyncShouldReturnList()
    {
        // Arrange
        var schoolsRepository = InitializeMockSchoolRepository();
        var sut = InitializeSchoolsService(schoolsRepository);

        // Act
        var result = await sut.GetSchoolsAsync();

        // Assert
        schoolsRepository.Verify(x => x.GetSchoolsAsync(), Times.Once());
        result.Should().BeAssignableTo<IList<School>>();
    }

    [Fact(DisplayName = "PatchSchoolsAsync should return a bool")]
    public async Task PatchSchoolsAsyncShouldReturnBool()
    {
        // Arrange
        var schoolsRepository = InitializeMockSchoolRepository();
        schoolsRepository.Setup(x => x.PatchSchoolsAsync(It.IsAny<PatchRequest<string>>())).ReturnsAsync(true);
        var sut = InitializeSchoolsService(schoolsRepository);

        var id = Guid.NewGuid().ToString();

        var patchRequest = new PatchRequest<string> { Id = Guid.NewGuid(), PropertyName = id, PropertyValue = "Test Patch" };
        var patchRequestSerialized = JsonSerializer.Serialize(patchRequest);
        var buffer = Encoding.UTF8.GetBytes(patchRequestSerialized);

        using var stream = new MemoryStream(buffer);

        // Act
        var result = await sut.PatchSchoolAsync(id, stream);

        // Assert
        schoolsRepository.Verify(x => x.PatchSchoolsAsync(It.IsAny<PatchRequest<string>>()), Times.Once());
        result.Should().Be(true);
    }

    [Fact(DisplayName = "PostSchoolsAsync should return a bool")]
    public async Task PostSchoolsAsyncShouldReturnBool()
    {
        // Arrange
        var schoolsRepository = InitializeMockSchoolRepository();
        var sut = InitializeSchoolsService(schoolsRepository);

        // Act
        var result = await sut.PostSchoolAsync(SchoolMock);

        // Assert
        schoolsRepository.Verify(x => x.PostSchoolsAsync(SchoolMock), Times.Once());
        result.Should().Be(true);
    }

    private static Mock<ISchoolsRepository> InitializeMockSchoolRepository()
    {
        var schoolRepository = new Mock<ISchoolsRepository>();
        schoolRepository.Setup(x => x.GetSchoolsAsync()).ReturnsAsync([]);
        schoolRepository.Setup(x => x.GetSchoolsAsync(It.IsAny<Guid>())).ReturnsAsync(SchoolMock);
        schoolRepository.Setup(x => x.PostSchoolsAsync(SchoolMock)).ReturnsAsync(true);
        return schoolRepository;
    }

    private static SchoolsService InitializeSchoolsService(Mock<ISchoolsRepository> schoolRepository)
    {
        var logger = new NullLogger<SchoolsService>();
        return new SchoolsService(logger, schoolRepository.Object);
    }
}