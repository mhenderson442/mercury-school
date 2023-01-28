namespace MercurySchool.Api.Repositories;

internal class PersonRepository : IPersonRepository
{
    private readonly IDataAccessFactory _dataAccessFactory;
    public PersonRepository(IDataAccessFactory dataAccessFactory) => _dataAccessFactory = dataAccessFactory;

    public async Task<IList<Person>> GetPersonsAsync(string accountId)
    {
        var persons = new List<Person>();
        var container = await _dataAccessFactory.GetPersonContainerAsync();
        var queryable = container.GetItemLinqQueryable<Person>();

        var matches = queryable.Where(x => x.AccountId == accountId);

        using var linqFeed = matches.ToFeedIterator();

        while (linqFeed.HasMoreResults)
        {
            FeedResponse<Person> response = await linqFeed.ReadNextAsync();
            persons.AddRange(response.ToList<Person>());
        }

        if (persons is null)
        {
            throw new NullReferenceException(nameof(persons));
        }

        return persons;
    }

    public async Task<ItemResponse<Person>> UpsertPersonItemAsync(Person person)
    {
        var container = await _dataAccessFactory.GetPersonContainerAsync();
        var itemResponse = await container.UpsertItemAsync<Person>(item: person);

        return itemResponse;
    }
}
