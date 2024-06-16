namespace MercurySchool.DataAccess.Respositories;

public interface ISchoolsRepository
{
    /// <summary>
    /// Get school data from database
    /// </summary>
    /// <param name="id">Primary key</param>
    /// <returns><see cref="School">School</see></returns>
    Task<School?> GetSchoolsAsync(Guid id);

    /// <summary>
    /// Get list of school from database
    /// </summary>
    /// <returns>List of type <see cref="School">School</see></returns>
    Task<IList<School>> GetSchoolsAsync();

    /// <summary>
    /// Update property in database
    /// </summary>
    /// <param name="patchRequest"><see cref="PatchRequest{T}">PatchRequest</see></param>
    /// <returns>Bool indicating succcess</returns>
    Task<bool> PatchSchoolsAsync(PatchRequest<string> patchRequest);

    /// <summary>
    /// Create new row in database
    /// </summary>
    /// <param name="school"><see cref="School">School</see></param>
    /// <returns>Bool indicating succcess</returns>
    Task<bool> PostSchoolsAsync(School school);
}