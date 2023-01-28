namespace MercurySchool.Api.Repositories;

public interface IPersonRepository
{
    Task<IList<Person>> GetPersonsAsync(string accountId);

    Task<ItemResponse<Person>> UpsertPersonItemAsync(Person person);
}
