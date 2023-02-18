namespace MercurySchool.Api.Repositories;

/// <summary>
/// Student Repository interface
/// </summary>
public interface IStudentRepository
{
    /// <summary>
    /// Get list of type PatchOperation
    /// </summary>
    /// <param name="student"><see cref="Student">Instance of student</see></param>
    /// <returns>List of type <see cref="PatchOperation">PatchOperation</see></returns>
    Task<List<PatchOperation>> AddStudentPatchOperationsAsync(Student student);

    /// <summary>
    /// Add person to data store.
    /// </summary>
    /// <param name="patchOperations">Instance for <see cref="PatchOperation">PatchOperation</see></param>
    /// <param name="accountId">Account ID</param>
    /// <param name="personId">Person id</param>
    /// <returns>Instance of ItemResponse of type <see cref="Person">Person</see></returns>
    Task<ItemResponse<Person>> PatchPersonItemAddStudentAsync(List<PatchOperation> patchOperations, string accountId, string personId);
}
