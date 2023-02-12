namespace MercurySchool.Api.Controllers;

/// <summary>
/// Student Controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    /// <summary>
    /// Student Controller constructor
    /// </summary>
    /// <param name="studentRepository"><see cref="IStudentRepository">Injects instance of IPersonRepository</see></param>
    public StudentController(IStudentRepository studentRepository) => _studentRepository = studentRepository;

    /// <summary>
    /// Update student
    /// </summary>
    /// <param name="student"><see cref="Student">Instance of student</see></param>
    /// <param name="accountId">Account Id</param>
    /// <param name="personId">Person Id</param>
    /// <returns></returns>
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
