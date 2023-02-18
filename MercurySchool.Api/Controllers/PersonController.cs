namespace MercurySchool.Api.Controllers;

/// <summary>
/// Person controller
/// </summary>
[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    readonly IPersonRepository _personRepository;

    /// <summary>
    /// Person controller
    /// </summary>
    /// <param name="personRepository"><see cref="IPersonRepository">Injects instance of IPersonRepository</see></param>
    public PersonController(IPersonRepository personRepository) => _personRepository = personRepository;

    /// <summary>
    /// Get a list of persons filtered on account id
    /// </summary>
    /// <param name="accountId">Id account account linked to a person.</param>
    /// <returns><see cref="IActionResult"></see></returns>
    [HttpGet]
    public async Task<IActionResult> GetAsync(string accountId)
    {
        var persons = await _personRepository.GetPersonsAsync(accountId);

        if (persons is null || persons.Count == 0)
        {
            return NotFound($"Unable to find persons associated with {accountId}");
        }

        return Ok(persons);
    }

    /// <summary>
    /// Insert new person
    /// </summary>
    /// <param name="person"></param>
    /// <returns><see cref="IActionResult"></see></returns>
    [HttpPost]
    public async Task<IActionResult> PostAsync(Person person)
    {
        var itemResponse = await _personRepository.UpsertPersonItemAsync(person);
        return Ok(itemResponse.Resource);
    }
}
