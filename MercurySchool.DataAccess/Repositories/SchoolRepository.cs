namespace MercurySchool.DataAccess.Repositories;

/// <inheritdoc>
public class SchoolRepository(IDatabaseConnections _sqlConnection) : ISchoolRepository
{
    public async Task<School> GetSchoolAsync(Guid id)
    {
        var storedProcedureName = "api.GetSchool";

        var values = new { Id = id };
        var result = await _sqlConnection.Connection.QueryAsync<School>(storedProcedureName, values);

        return result.FirstOrDefault()!;
    }

    public async Task<IEnumerable<School>> GetSchoolsAsync()
    {
        var storedProcedureName = "api.GetSchools";
        var result = await _sqlConnection.Connection.QueryAsync<School>(storedProcedureName);

        return result is null ? throw new NullReferenceException(storedProcedureName) : result;
    }

    public async Task<bool> InsertSchoolAsync(School school)
    {
        var storedProcedureName = "api.InsertSchool";
        var result = await _sqlConnection.Connection.ExecuteAsync(storedProcedureName, school, commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public async Task<bool> UpdateSchoolAsync(School school)
    {
        var storedProcedureName = "api.UpdateSchool";
        var values = new { school.Id, school.Description, school.Name };
        var result = await _sqlConnection.Connection.ExecuteAsync(storedProcedureName, values, commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public async Task<bool> UpdateSchoolDescriptionAsync(Guid id, string description)
    {
        var storedProcedureName = "api.UpdateSchoolDescription";
        var values = new { id, description };

        var result = await _sqlConnection.Connection.ExecuteAsync(storedProcedureName, values, commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public async Task<bool> UpdateSchoolNameAsync(Guid id, string name)
    {
        var storedProcedureName = "api.UpdateSchoolName";
        var values = new { id, name };

        var result = await _sqlConnection.Connection.ExecuteAsync(storedProcedureName, values, commandType: CommandType.StoredProcedure);

        return result > 0;
    }
}