namespace MercurySchool.Api.Models;

/// <summary>
/// Student
/// </summary>
public class Student
{
    private string _id;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="id">Student Id</param>
    [SetsRequiredMembers]
    public Student(string id) => Id = _id = id;

    /// <summary>
    /// Student's academic status
    /// </summary>
    public string? AcademicStatus { get; set; }

    /// <summary>
    /// Student's Id
    /// </summary>
    required public string Id { get => _id; init => _id = value; }
}
