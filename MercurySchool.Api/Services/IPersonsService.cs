using System;

namespace MercurySchool.Api.Services;

public interface IPersonsService
{
    /// <summary>
    /// Get list of persons
    /// </summary>
    /// <returns>List of type <see cref="Person">Person</see></returns>
    Task<IList<Person>> GetPersonsAsync();

    /// <summary>
    /// Get list of persons where last name starts with parameter value.
    /// </summary>
    /// <param name="startsWithValue">First letter of last name.</param>
    /// <returns>List of type <see cref="Person">Person</see></returns>
    Task<IList<Person>> GetPersonsAsync(string startsWithValue);

    /// <summary>
    /// Patch property of person
    /// </summary>
    /// <param name="id">Person id</param>
    /// <param name="requestBody">Propety and value to patch</param>
    /// <returns><see cref="bool"/> indicating success</returns>
    Task<bool> PatchPersonsAsync(string id, Stream requestBody);

    /// <summary>
    /// Create a new person in data store
    /// </summary>
    /// <param name="person"><see cref="Person">Person</see> to be created</param>
    /// <returns><see cref="bool"/> indicating success</returns>
    Task<bool> PostPersonsAsync(Person person);

    /// <summary>
    /// Update person entity in data store
    /// </summary>
    /// <param name="person"><see cref="Person">Person</see> to be created</param>
    /// <returns><see cref="bool"/> indicating success</returns>
    Task<bool> PutPersonsAsync(Person person);

    /// <summary>
    /// Delee person entity in data store
    /// </summary>
    /// <param name="id">Person id</param>
    /// <returns><see cref="bool"/> indicating success</returns>
    Task<bool> DeletePersonsAsync(string id);
}