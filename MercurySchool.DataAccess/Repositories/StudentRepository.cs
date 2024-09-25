using Dapper;
using MercurySchool.DataAccess.Connections;
using MercurySchool.Models.Entities;
using System.Data;

namespace MercurySchool.DataAccess.Repositories;

/// <inheritdoc>
public class StudentRepository(IDatabaseConnections _sqlConnection) : IStudentRepository
{
    public async Task<IEnumerable<Student>> GetStudentRepositoryAsync(int pageNumber, int pageSize, string? lastNameStartsWith)
    {
        var storedProcedureName = "api.GetStudents";
        var inputParameters = new { PageNumber = pageNumber, PageSize = pageSize, LastNameStartsWith = lastNameStartsWith };
        var result = await _sqlConnection.Connection.QueryAsync<Student>(storedProcedureName, inputParameters, commandType: CommandType.StoredProcedure);

        return result;
    }

    public async Task<bool> InsertStudentAsync(Student student)
    {
        var storedProcedureName = "api.InsertStudent";

        var inputParameters = new { PersonId = student.Person.Id, StudentAcademicStatusId = student.StudentAcademicStatus.Id };
        var result = await _sqlConnection.Connection.ExecuteAsync(storedProcedureName, inputParameters);

        return result > 0;
    }
}