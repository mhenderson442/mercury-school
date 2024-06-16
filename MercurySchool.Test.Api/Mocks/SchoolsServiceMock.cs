namespace MercurySchool.Test.Api.Mocks;

public class SchoolsServiceMock : ISchoolsService
{
    public async Task<School?> GetSchoolAsync(string id)
    {
        await Task.Yield();
        return new School() { Id = Guid.Parse(TestBase.SchoolId), Name = Guid.NewGuid().ToString() };
    }

    public async Task<IList<School>> GetSchoolsAsync()
    {
        await Task.Yield();
        var school = new School { Id = Guid.Parse(TestBase.SchoolId), Name = Guid.NewGuid().ToString() };
        var schools = new List<School>() { school };

        return schools;
    }

    public async Task<bool> PatchSchoolAsync(string id, Stream requestBody)
    {
        await Task.Yield();
        return true;
    }

    public async Task<bool> PostSchoolAsync(School school)
    {
        await Task.Yield();
        return true;
    }
}