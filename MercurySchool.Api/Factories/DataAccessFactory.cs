namespace MercurySchool.Api.Factories;

internal class DataAccessFactory : IDataAccessFactory
{
    private readonly CosmosClient _cosmosClient;

    public DataAccessFactory(CosmosClient cosmosClient) => _cosmosClient = cosmosClient;

    public async Task<Container> GetPersonContainerAsync() => await GetContainerAsync(CosmosDbConstants.PersonContainer);

    public async Task<Container> GetReferenceDataContainerAsync() => await GetContainerAsync(CosmosDbConstants.ReferenceContainer);

    private async Task<Container> GetContainerAsync(string containerName)
    {
        await Task.Yield();

        var container = _cosmosClient.GetContainer(CosmosDbConstants.SchoolDatabase, containerName);

        if (container is null)
        {
            throw new NullReferenceException($"Unable to retrieve {containerName} container");
        }

        return container;
    }
}
