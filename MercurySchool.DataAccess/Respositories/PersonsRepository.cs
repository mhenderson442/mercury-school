using MercurySchool.DataAccess.Factories;
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
    public async Task<IList<Person>> GetPersonsAsync(string startsWithValue)
    {
        await Task.Yield();
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task<IList<Person>> GetPersonsAsync()
    {
        using var sqlConnection = await _connectionFactory.CreateAsync();
        await sqlConnection.OpenAsync();

        using var sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        sqlCommand.CommandText = "api.GetPersons";

        using var reader = await sqlCommand.ExecuteReaderAsync();

        var persons = new List<Person>();

        while (await reader.ReadAsync())
        {
            var person = new Person
            {
                Id = reader.GetGuid(0),
                FirstName = reader.GetString(1),
                MiddleName = reader.GetString(2),
                LastName = reader.GetString(3),
            };

            persons.Add(person);
        }

        return persons;
    }

    //var person = new Person
    //{
    //    Id = reader.GetGuid(0),
    //    FirstName = reader.GetString(1),
    //    MiddleName = reader.GetString(2),
    //    LastName = reader.GetString(3),
    //}
    public async Task<bool> PatchPersonsAsync(PatchRequest<string> patchRequest)
    {
        await Task.Yield();
        throw new NotImplementedException();
    }

    /// <inheritdoc/
    public async Task<bool> PostPersonsAsync(Person person)
    {
        await Task.Yield();
        throw new NotImplementedException();
    }

    public async Task<bool> PutPersonsAsync(Person person)
    {
        await Task.Yield();
        throw new NotImplementedException();
    }
}