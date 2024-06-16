namespace MercurySchool.Api.Services;

/// <summary>
/// Implementation of <see cref="ISchoolsService"/>.
/// </summary>
/// <param name="logger"><see cref="ILogger<SchoolsService>"/></param>
/// <param name="schoolRepository"><see cref="ISchoolsRepository"/></param>
public class SchoolsService(ILogger<SchoolsService> logger, ISchoolsRepository schoolRepository) : ISchoolsService
{
    private readonly ILogger _logger = logger;
    private readonly ISchoolsRepository _schoolRepository = schoolRepository;

    /// <inheritdoc />
    public async Task<School?> GetSchoolAsync(string id)
    {
        _logger.LogInformation("{method} was called", nameof(GetSchoolAsync));
        var isValidId = Guid.TryParse(id, out Guid schoolId);
        var school = isValidId ? await _schoolRepository.GetSchoolsAsync(schoolId) : null;
        return school;
    }

    /// <inheritdoc />
    public async Task<IList<School>> GetSchoolsAsync()
    {
        _logger.LogInformation("{method} was called", nameof(GetSchoolsAsync));
        var schools = await _schoolRepository.GetSchoolsAsync();
        return schools;
    }

    /// <inheritdoc />
    public async Task<bool> PatchSchoolAsync(string id, Stream requestBody)
    {
        var streamReader = new StreamReader(requestBody);
        var content = await streamReader.ReadToEndAsync();
        var patchRequest = JsonSerializer.Deserialize<PatchRequest<string>>(content);

        if (patchRequest is null)
        {
            return false;
        }

        return await _schoolRepository.PatchSchoolsAsync(patchRequest);
    }

    /// <inheritdoc />
    public async Task<bool> PostSchoolAsync(School school)
    {
        _logger.LogInformation("{method} was called", nameof(PostSchoolAsync));
        var wasCreated = await _schoolRepository.PostSchoolsAsync(school);

        return wasCreated;
    }
}