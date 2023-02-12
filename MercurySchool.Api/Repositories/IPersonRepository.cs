namespace MercurySchool.Api.Repositories;

/// <summary>
/// Person repository interface
/// </summary>
public interface IPersonRepository
{
    /// <summary>
    /// Get persons from data store by account id
    /// </summary>
    /// <param name="accountId">Account Id</param>
    /// <returns>List of type <see cref="Person">Person</see></returns>
    Task<IList<Person>> GetPersonsAsync(string accountId);


    /// <summary>
    /// Update person
    /// </summary>
    /// <param name="person"></param>
    /// <returns>Instance of ItemResponse of type <see cref="Person">Person</see></returns>
    Task<ItemResponse<Person>> UpsertPersonItemAsync(Person person);
}
