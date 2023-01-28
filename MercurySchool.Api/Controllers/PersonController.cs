namespace MercurySchool.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    readonly IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository) => _personRepository = personRepository;

    [HttpGet]
    public async Task<IActionResult> GetAsync(string accountId)
    {
        try
        {
            var persons = await _personRepository.GetPersonsAsync(accountId);

            if (persons is null || persons.Count == 0)
            {
                return NotFound($"Unable to find persons associated with {accountId}");
            }

            return Ok(persons);
        }
        catch (NullReferenceException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Person person)
    {
        var itemResponse = await _personRepository.UpsertPersonItemAsync(person);
        return Ok(itemResponse.Resource);
    }
}
