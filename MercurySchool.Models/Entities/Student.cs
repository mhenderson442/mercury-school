namespace MercurySchool.Models.Entities;

/// <summary>
/// An instance of a student
/// </summary>
public class Student
{
    /// <summary>
    /// An instance of a person
    /// </summary>
    public required Person Person { get; init; }

    /// <summary>
    /// The student's academic status
    /// </summary>
    public required StudentAcademicStatus StudentAcademicStatus { get; init; }
}