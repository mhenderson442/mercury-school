namespace MercurySchool.Api.Repositories;

internal class ReferenceDataRepository : IReferenceDataRepository
{
    private readonly IDataAccessFactory _dataAccessFactory;

    public ReferenceDataRepository(IDataAccessFactory dataAccessFactory) => _dataAccessFactory = dataAccessFactory;

    public async Task<List<string>> GetReferenceDataAsync(string referenceDataType)
    {
        var referenceDataItems = new List<string>();
        var container = await _dataAccessFactory.GetReferenceDataContainerAsync();

        var queryable = container.GetItemLinqQueryable<ReferenceDataItem>();
        var matches = queryable.Where(x => x.Type == referenceDataType);

        using var linqFeed = matches.ToFeedIterator();

        while (linqFeed.HasMoreResults)
        {
            FeedResponse<ReferenceDataItem> response = await linqFeed.ReadNextAsync();
            var list = response.Select(x => x.Name).ToList();

            referenceDataItems.AddRange(list);
        }

        if (referenceDataItems is null)
        {
            throw new NullReferenceException(nameof(referenceDataItems));
        }

        return referenceDataItems;

    }
}
