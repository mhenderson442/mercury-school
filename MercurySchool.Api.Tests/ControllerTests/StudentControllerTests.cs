namespace MercurySchool.Api.Tests.ControllerTests;
public class StudentControllerTests : TestClassBase
{
    [Fact]
    [Trait("Category", "Unit")]
    public async Task PatchAsyncReturnsStudent()
    {
        // Arrange
        var student = InitMockedStudent();
        var responseMock = new Mock<ItemResponse<Person>>();

        var accountId = Guid.NewGuid().ToString();
        var personId = Guid.NewGuid().ToString();

        var patchOperations = new List<PatchOperation>()
        {
            PatchOperation.Add("/student", student)
        };

        var mockStudentRepository = CreateMockStudentRepository();
        mockStudentRepository.Setup(x => x.PatchPersonItemAddStudentAsync(It.IsAny<List<PatchOperation>>(), accountId, personId)).ReturnsAsync(responseMock.Object);

        var sut = CreateStudentController(mockStudentRepository);

        // Act
        var result = (OkObjectResult)await sut.PatchPersonAddStudentAsync(student, accountId, personId);

        // Assert
        mockStudentRepository.Verify(x => x.PatchPersonItemAddStudentAsync(It.IsAny<List<PatchOperation>>(), accountId, personId));

        result.Should()
            .NotBeNull().And
            .BeAssignableTo<OkObjectResult>();
    }



    private static StudentController CreateStudentController(Mock<IStudentRepository> mockStudentRepository) => new(mockStudentRepository.Object);
}