using MercurySchool.DataAccess.Factories;

namespace MercurySchool.DataAccess.Respositories;

public class SchoolsRepository(ISqlConnectionFactory sqlConnectionFactory) : ISchoolsRepository
{
    private readonly ISqlConnectionFactory _connectionFactory = sqlConnectionFactory;

    /// <inheritdoc/>
    public async Task<School?> GetSchoolsAsync(Guid id)
    {
        using var sqlConnection = await _connectionFactory.CreateAsync();
        await sqlConnection.OpenAsync();

        using var sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        sqlCommand.CommandText = "api.GetSchool";
        sqlCommand.Parameters.AddWithValue("@id", id);

        using var reader = await sqlCommand.ExecuteReaderAsync();

        if (reader.HasRows)
        {
            await reader.ReadAsync();
            var school = new School { Id = reader.GetGuid(0), Name = reader.GetString(1) };
            return school;
        }

        return null;
    }

    /// <inheritdoc/>
    public async Task<IList<School>> GetSchoolsAsync()
    {
        using var sqlConnection = await _connectionFactory.CreateAsync();
        await sqlConnection.OpenAsync();

        using var sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        sqlCommand.CommandText = "api.GetSchools";

        using var reader = await sqlCommand.ExecuteReaderAsync();

        if (!reader.HasRows)
        {
            return [];
        }

        var schools = new List<School>();

        while (await reader.ReadAsync())
        {
            var school = new School
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2)
            };

            schools.Add(school);
        }

        return schools;
    }

    /// <inheritdoc/>
    public async Task<bool> PatchSchoolsAsync(PatchRequest<string> patchRequest)
    {
        using var sqlConnection = await _connectionFactory.CreateAsync();
        await sqlConnection.OpenAsync();

        using var sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        sqlCommand.CommandText = "api.UpdateSchools";
        sqlCommand.Parameters.AddWithValue("@Id", patchRequest.Id);
        sqlCommand.Parameters.AddWithValue("@PropertyName", patchRequest.PropertyName);
        sqlCommand.Parameters.AddWithValue("@PropertyValue", patchRequest.PropertyValue);

        var result = await sqlCommand.ExecuteNonQueryAsync();

        return result == 1;
    }

    /// <inheritdoc/>
    public async Task<bool> PostSchoolsAsync(School school)
    {
        using var sqlConnection = await _connectionFactory.CreateAsync();
        await sqlConnection.OpenAsync();

        using var sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        sqlCommand.CommandText = "api.InsertSchools";
        sqlCommand.Parameters.AddWithValue("@Id", school.Id);
        sqlCommand.Parameters.AddWithValue("@Name", school.Name);
        sqlCommand.Parameters.AddWithValue("@Description", school.Name);

        var result = await sqlCommand.ExecuteNonQueryAsync();

        return result == 1;
    }
}