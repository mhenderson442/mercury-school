namespace MercurySchool.Api.Repositories;

/// <summary>
/// Student Repository
/// </summary>
public class StudentRepository : IStudentRepository
{
    private readonly IDataAccessFactory _dataAccessFactory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dataAccessFactory">Inject an instance of <see cref="IDataAccessFactory"></see></param>
    public StudentRepository(IDataAccessFactory dataAccessFactory) => _dataAccessFactory = dataAccessFactory;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="patchOperations"></param>
    /// <param name="accountId"></param>
    /// <param name="personId"></param>
    /// <returns></returns>
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
