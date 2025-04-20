namespace MercurySchool.DataAccess.Repositories;

/// <summary>
/// The StudentAcademicStatus repository
/// </summary>
public interface IStudentAcademicStatusRespository
{
    /// <summary>
    /// Get an instance of a <see cref="StudentAcademicStatus"/> filtered on the id
    /// </summary>
    /// <returns>An <see cref="IEnumerable"/> or <see cref="StudentAcademicStatus"/></returns>
    Task<IEnumerable<StudentAcademicStatus>> GetStudentAcademicStatuses();
}