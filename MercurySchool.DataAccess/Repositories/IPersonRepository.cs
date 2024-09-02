using MercurySchool.Models.Entities;

namespace MercurySchool.DataAccess.Repositories;

/// <summary>
/// The Person repository
/// </summary>
public interface IPersonRepository
{
    /// <summary>
    /// A Paginated list of persons
    /// </summary>
    /// <param name="pageNumber">The page number</param>
    /// <param name="pageSize">The number of rows to return</param>
    /// <param name="lastNameStartsWith">First letter of last name</param>
    /// <returns>An instance of <see cref="IEnumerable{T}>"/> of type Person.</returns>
    Task<IEnumerable<Person>> GetPersons(int pageNumber, int pageSize, string? lastNameStartsWith);

    /// <summary>
    /// Insert new person into database
    /// </summary>
    /// <param name="person">Instance of a <see cref="Person"/> to be inserted into the database.</param>
    /// <returns>A <see cref="bool"/> indicating sucess of the insert.</returns>
    Task<bool> InsertSchoolAsync(Person person);

    /// <summary>
    /// Update person in database
    /// </summary>
    /// <param name="person">Instance of a <see cref="Person"/> to be inserted into the database.</param>
    /// <returns>A <see cref="bool"/> indicating sucess of the insert.</returns>
    Task<bool> UpdateSchoolAsync(Person person);
}