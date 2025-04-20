namespace MercurySchool.DataAccess.Repositories;

public class StudentAcademicStatusRespository(IDatabaseConnections _sqlConnection) : IStudentAcademicStatusRespository
{
    public async Task<IEnumerable<StudentAcademicStatus>> GetStudentAcademicStatuses()
    {
        var storedProcedureName = "api.GetStudentAcademicStatuses";
        var result = await _sqlConnection.Connection.QueryAsync<StudentAcademicStatus>(storedProcedureName);

        return result is null ? throw new NullReferenceException(storedProcedureName) : result;
    }
}