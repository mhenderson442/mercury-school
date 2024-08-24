using MercurySchool.Models.Entities;

namespace MercurySchool.DataAccess.Repositories;

public interface ISchoolRepository
{
    /// <summary>
    /// Get a list of all schools.
    /// </summary>
    /// <returns>An instance of <see cref="IEnumerable{T}>"/> of type School</returns>
    Task<IEnumerable<School>> GetSchoolAsync();

    /// <summary>
    /// Insert a new school in the database.
    /// </summary>
    /// <param name="school"></param>
    /// <returns>A <see cref="bool"/> indicating sucess</returns>
    Task<bool> InsertSchoolAsync(School school);
}