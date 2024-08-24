using Dapper;
using MercurySchool.DataAccess.Connections;
using MercurySchool.Models.Entities;
using System.Data;

namespace MercurySchool.DataAccess.Repositories;

/// <inheritdoc>
public class SchoolRepository(IDatabaseConnections _sqlConnection) : ISchoolRepository
{
    public async Task<IEnumerable<School>> GetSchoolAsync()
    {
        var storedProcedureName = "api.GetSchools";
        var result = await _sqlConnection.Connection.QueryAsync<School>(storedProcedureName);

        return result is null ? throw new NullReferenceException(storedProcedureName) : result;
    }

    public async Task<bool> InsertSchoolAsync(School school)
    {
        var storedProcedureName = "api.InsertSchools";
        var result = await _sqlConnection.Connection.ExecuteAsync(storedProcedureName, school, commandType: CommandType.StoredProcedure);

        return result > 0;
    }
}