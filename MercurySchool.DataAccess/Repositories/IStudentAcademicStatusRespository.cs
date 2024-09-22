using MercurySchool.Models.Entities;

namespace MercurySchool.DataAccess.Repositories;

public interface IStudentAcademicStatusRespository
{
    Task<IEnumerable<StudentAcademicStatus>> GetStudentAcademicStatuses();
}