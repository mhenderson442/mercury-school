using MercurySchool.DataAccess.Factories;
using MercurySchool.Models;
using System.Reflection.PortableExecutable;

namespace MercurySchool.DataAccess.Respositories;

public class PersonsRepository(ISqlConnectionFactory sqlConnectionFactory) : IPersonsRepository
{
    private readonly ISqlConnectionFactory _connectionFactory = sqlConnectionFactory;

    public async Task<bool> DeletePersonsAsync(string id)
    {
        await Task.Yield();
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task<IList<Person>> GetPersonsAsync(string startsWithValue) => await GetPersonsBaseAsync(startsWithValue);

    /// <inheritdoc/>
    public async Task<IList<Person>> GetPersonsAsync() => await GetPersonsBaseAsync();

    /// <inheritdoc/>
    public async Task<bool> PatchPersonsAsync(PatchRequest<string> patchRequest)
    {
        using var sqlConnection = await _connectionFactory.CreateAsync();
        await sqlConnection.OpenAsync();

        using var sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        sqlCommand.CommandText = "api.PatchPersons";

        sqlCommand.Parameters.AddWithValue("@Id", patchRequest.Id);
        sqlCommand.Parameters.AddWithValue("@PropertyName", patchRequest.PropertyName);
        sqlCommand.Parameters.AddWithValue("@PropertyValue", patchRequest.PropertyValue);

        var result = await sqlCommand.ExecuteNonQueryAsync();

        return result == 1;
    }

    /// <inheritdoc/>
    public async Task<bool> PostPersonsAsync(Person person)
    {
        using var sqlConnection = await _connectionFactory.CreateAsync();
        await sqlConnection.OpenAsync();

        using var sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        sqlCommand.CommandText = "api.PostPersons";

        sqlCommand.Parameters.AddWithValue("@Id", person.Id);
        sqlCommand.Parameters.AddWithValue("@FirstName", person.FirstName);
        sqlCommand.Parameters.AddWithValue("@LastName", person.LastName);

        if (person.MiddleName is not null)
        {
            sqlCommand.Parameters.AddWithValue("@MiddleName", person.MiddleName);
        }

        var result = await sqlCommand.ExecuteNonQueryAsync();

        return result == 1;
    }

    public async Task<bool> PutPersonsAsync(Person person)
    {
        using var sqlConnection = await _connectionFactory.CreateAsync();
        await sqlConnection.OpenAsync();

        using var sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        sqlCommand.CommandText = "api.PutPersons";

        sqlCommand.Parameters.AddWithValue("@Id", person.Id);
        sqlCommand.Parameters.AddWithValue("@FirstName", person.FirstName);
        sqlCommand.Parameters.AddWithValue("@LastName", person.LastName);

        if (person.MiddleName is not null)
        {
            sqlCommand.Parameters.AddWithValue("@MiddleName", person.MiddleName);
        }

        var result = await sqlCommand.ExecuteNonQueryAsync();

        return result == 1;
    }

    private async Task<IList<Person>> GetPersonsBaseAsync(string? startsWithValue = null)
    {
        using var sqlConnection = await _connectionFactory.CreateAsync();
        await sqlConnection.OpenAsync();

        using var sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        sqlCommand.CommandText = "api.GetPersons";

        if (startsWithValue is not null)
        {
            sqlCommand.Parameters.AddWithValue("@StartsWith", startsWithValue);
        }

        using var reader = await sqlCommand.ExecuteReaderAsync();

        var persons = new List<Person>();

        while (await reader.ReadAsync())
        {
            var person = new Person
            {
                Id = reader.GetGuid(0),
                FirstName = reader.GetString(1),
                MiddleName = await reader.IsDBNullAsync(2) ? null : reader.GetString(2),
                LastName = reader.GetString(3),
            };

            persons.Add(person);
        }

        return persons;
    }
}