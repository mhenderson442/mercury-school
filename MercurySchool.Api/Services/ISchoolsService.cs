namespace MercurySchool.Api.Services;

/// <summary>
/// ISchoolsService interface
/// </summary>
public interface ISchoolsService
{
    /// <summary>
    /// Get school by Id
    /// </summary>
    /// <param name="id"><see cref="string"/>Id</param>
    /// <returns><see cref="School"/></returns>
    Task<School?> GetSchoolAsync(string id);

    /// <summary>
    /// Get complete list of schools
    /// </summary>
    /// <returns><see cref="IList{School}"/></returns>
    Task<IList<School>> GetSchoolsAsync();

    /// <summary>
    /// Patch property of school
    /// </summary>
    /// <param name="id"></param>
    /// <param name="requestBody"></param>
    /// <returns></returns>
    Task<bool> PatchSchoolAsync(string id, Stream requestBody);

    /// <summary>
    /// Create school record
    /// </summary>
    /// <param name="school"><see cref="School"/></param>
    /// <returns></returns>
    Task<bool> PostSchoolAsync(School school);
}

