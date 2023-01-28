namespace MercurySchool.Api.Tests.RepositoryTests;
public class StudentRespositoryTests : TestClassBase
{
    private readonly string _accountId = "156600";


    [Theory(DisplayName = "StudentItemAsync Should Return Item")]
    [InlineData("B127BB59-42FD-4E51-8681-72C43CB46373", "8abeae0a-21ef-48b7-b7f3-8afac6fe5c3e")]
    //[InlineData(null, "1626bfea-9a32-48f0-a36a-43f3922cebd8")]
    [Trait("Category", "Integration")]
    public async Task UpsertStudentItemShouldReturnItem(string? id, string personId)
    {

        // Arrange
        id ??= Guid.NewGuid().ToString();
        var student = new Student(id: id);

        IStudentRepository sut = CreatStudentRepository();

        var patchOperations = new List<PatchOperation>()
        {
            PatchOperation.Add("/student", student)
        };

        // Act
        var result = await sut.PatchPersonItemAddStudentAsync(patchOperations, _accountId, personId);

        // Assert
        result.Should().NotBeNull().And.BeAssignableTo<ItemResponse<Person>>();
    }

    private static IStudentRepository CreatStudentRepository()
    {
        var databaseAccessFactory = CreateDataAccessFactory();
        IStudentRepository studentRepository = new StudentRepository(databaseAccessFactory);
        return studentRepository;
    }
}
