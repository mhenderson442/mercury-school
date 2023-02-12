namespace MercurySchool.Api.Repositories;

/// <summary>
/// Student Repository interface
/// </summary>
public interface IStudentRepository
{
    /// <summary>
    /// Add person to data store.
    /// </summary>
    /// <param name="patchOperations">Instance for <see cref="PatchOperation">PatchOperation</see></param>
    /// <param name="accountId">Account ID</param>
    /// <param name="personId">Person id</param>
    /// <returns>Instance of ItemResponse of type <see cref="Person">Person</see></returns>
    Task<ItemResponse<Person>> PatchPersonItemAddStudentAsync(List<PatchOperation> patchOperations, string accountId, string personId);
}
