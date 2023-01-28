namespace MercurySchool.Api.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IDataAccessFactory _dataAccessFactory;

    public StudentRepository(IDataAccessFactory dataAccessFactory) => _dataAccessFactory = dataAccessFactory;


    public async Task<ItemResponse<Person>> PatchPersonItemAddStudentAsync(List<PatchOperation> patchOperations, string accountId, string personId)
    {
        var partitionKey = new PartitionKey(accountId);
        var container = await _dataAccessFactory.GetPersonContainerAsync();

        var itemResponse = await container.PatchItemAsync<Person>(
            id: personId,
            partitionKey: partitionKey,
            patchOperations: patchOperations
            );

        return itemResponse;
    }
}
