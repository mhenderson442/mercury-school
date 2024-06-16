namespace MercurySchool.Api.Services;

/// <summary>
/// Implementation of <see cref="IPersonsService"/>.
/// </summary>
/// <param name="logger"><see cref="ILogger<PersonsService>">ILogger</param>
/// <param name="personsRepository"><see cref="IPersonRepository">IPersonRepository</see></param>
public class PersonsService(ILogger<PersonsService> logger, IPersonsRepository personsRepository) : IPersonsService
{
    private readonly ILogger _logger = logger;
    private readonly IPersonsRepository _personsRepository = personsRepository;

    public async Task<bool> DeletePersonsAsync(string id)
    {
        _logger.LogInformation("{method} was called", nameof(DeletePersonsAsync));
        return await _personsRepository.DeletePersonsAsync(id);
    }

    /// <inheritdoc />
    public async Task<Person> GetPersonsAsync(Guid id)
    {
        _logger.LogInformation("{method} was called", nameof(GetPersonsAsync));
        var person = await _personsRepository.GetPersonsAsync(id);

        return person;
    }

    /// <inheritdoc />
    public async Task<IList<Person>> GetPersonsAsync(string? startsWithValue)
    {
        _logger.LogInformation("{method} was called", nameof(GetPersonsAsync));
        var persons = await _personsRepository.GetPersonsAsync(startsWithValue);

        return persons;
    }

    public async Task<bool> PatchPersonsAsync(string id, Stream requestBody)
    {
        var streamReader = new StreamReader(requestBody);
        var content = await streamReader.ReadToEndAsync();
        var patchRequest = JsonSerializer.Deserialize<PatchRequest<string>>(content);

        if (patchRequest is null)
        {
            return false;
        }

        return await _personsRepository.PatchPersonsAsync(patchRequest);
    }

    /// <inheritdoc />
    public async Task<bool> PostPersonsAsync(Person person)
    {
        _logger.LogInformation("{method} was called", nameof(PostPersonsAsync));
        return await _personsRepository.PostPersonsAsync(person);
    }

    /// <inheritdoc />
    public async Task<bool> PutPersonsAsync(Person person)
    {
        _logger.LogInformation("{method} was called", nameof(PutPersonsAsync));
        return await _personsRepository.PutPersonsAsync(person);
    }
}