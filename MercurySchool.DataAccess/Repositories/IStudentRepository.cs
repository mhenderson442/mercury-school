using MercurySchool.Models.Entities;

namespace MercurySchool.DataAccess.Repositories;

public interface IStudentRepository
{
    /// <summary>
    ///A Paginated list of students
    /// </summary>
    /// <param name="pageNumber">The page number</param>
    /// <param name="pageSize">The number of rows to return</param>
    /// <param name="lastNameStartsWith">First letter of last name</param>
    /// <returns>An instance of <see cref="IEnumerable{T}>"/> of type Student.</returns>
    Task<IEnumerable<Student>> GetStudentRepositoryAsync(int pageNumber, int pageSize, string? lastNameStartsWith);

    /// <summary>
    /// Insert new student into database
    /// </summary>
    /// <param name="student">Instance of a <see cref="Student"/> to be inserted into the database.</param>
    /// <returns>A <see cref="bool"/> indicating sucess of the insert.</returns>
    Task<bool> InsertStudentAsync(Student student);
}