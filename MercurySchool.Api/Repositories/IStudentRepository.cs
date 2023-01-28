namespace MercurySchool.Api.Repositories;

public interface IStudentRepository
{
    Task<ItemResponse<Person>> PatchPersonItemAddStudentAsync(List<PatchOperation> patchOperations, string accountId, string personId);
}
