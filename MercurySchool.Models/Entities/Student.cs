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

    public required StudentAcademicStatus StudentAcademicStatus { get; init; }
}