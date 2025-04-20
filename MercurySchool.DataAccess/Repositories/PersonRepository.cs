namespace MercurySchool.DataAccess.Repositories;

/// <inheritdoc>
public class PersonRepository(IDatabaseConnections _sqlConnection) : IPersonRepository
{
    public async Task<IEnumerable<Person>> GetPersonsAsync(int pageNumber, int pageSize, string? lastNameStartsWith)
    {
        var storedProcedureName = "api.GetPersons";
        var inputParameters = new { PageNumber = pageNumber, PageSize = pageSize, LastNameStartsWith = lastNameStartsWith };
        var result = await _sqlConnection.Connection.QueryAsync<Person>(storedProcedureName, inputParameters, commandType: CommandType.StoredProcedure);

        return result;
    }

    public async Task<bool> InsertPersonAsync(Person person)
    {
        var storedProcedureName = "api.InsertPerson";
        var inputParameters = new { person.Id, person.FirstName, person.MiddleName, person.LastName, person.CreateDate };
        var result = await _sqlConnection.Connection.ExecuteAsync(storedProcedureName, inputParameters, commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public async Task<bool> UpdateSchoolAsync(Person person)
    {
        var storedProcedureName = "api.UpdatePerson";
        var inputParameters = new { person.Id, person.FirstName, person.MiddleName, person.LastName };
        var result = await _sqlConnection.Connection.ExecuteAsync(storedProcedureName, inputParameters, commandType: CommandType.StoredProcedure);

        return result > 0;
    }
}