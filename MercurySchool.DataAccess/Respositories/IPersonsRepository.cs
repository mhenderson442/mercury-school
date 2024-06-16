namespace MercurySchool.DataAccess.Respositories;

public interface IPersonsRepository
{
    /// <summary>
    /// Get all persons
    /// </summary>
    /// <returns></returns>
    Task<IList<Person>> GetPersonsAsync();

    /// <summary>
    /// Get all persons where last name start with value of parameter
    /// </summary>
    /// <param name="startsWithValue">First letter of last name</param>
    /// <returns><see cref="IList{T}">List</see> of type <see cref="Person">School</see></returns>
    Task<IList<Person>> GetPersonsAsync(string startsWithValue);

    /// <summary>
    /// Create a new person in Sql database
    /// </summary>
    /// <param name="person"><see cref="Person">Person</see> to be created</param>
    /// <returns><see cref="bool"/> indicating success</returns>
    Task<bool> PostPersonsAsync(Person person);

    /// <summary>
    /// Update person entity in Sql database
    /// </summary>
    /// <param name="person"><see cref="Person">Person</see> to be created</param>
    /// <returns><see cref="bool"/> indicating success</returns>
    Task<bool> PutPersonsAsync(Person person);

    /// <summary>
    /// Update property in database
    /// </summary>
    /// <param name="patchRequest"><see cref="PatchRequest{T}">PatchRequest</see></param>
    /// <returns>Bool indicating succcess</returns>
    Task<bool> PatchPersonsAsync(PatchRequest<string> patchRequest);

    /// <summary>
    /// Delete entity from data store
    /// </summary>
    /// <param name="id">Person Id</param>
    /// <returns>Bool indicating succcess</returns>
    Task<bool> DeletePersonsAsync(string id);
}