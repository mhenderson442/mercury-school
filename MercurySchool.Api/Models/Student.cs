namespace MercurySchool.Api.Models;

public class Student
{
    private string _id;

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
