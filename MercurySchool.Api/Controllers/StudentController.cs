namespace MercurySchool.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository) => _studentRepository = studentRepository;

    [HttpPatch]
    public async Task<IActionResult> PatchPersonAddStudentAsync(Student student, string accountId, string personId)
    {
        var patchOperations = AddStudentPatchOperations(student);
        var itemResponse = await PatchPersonWithStudentItemAsync(patchOperations, accountId, personId);

        return Ok(itemResponse.Resource);

    }

    private static List<PatchOperation> AddStudentPatchOperations(Student student)
    {
        var patchOperations = new List<PatchOperation>()
        {
            PatchOperation.Add("/student", student)
        };

        return patchOperations;
    }

    private async Task<ItemResponse<Person>> PatchPersonWithStudentItemAsync(List<PatchOperation> patchOperations, string accountId, string personId)
    {
        return await _studentRepository.PatchPersonItemAddStudentAsync(patchOperations, accountId, personId);
    }
}
