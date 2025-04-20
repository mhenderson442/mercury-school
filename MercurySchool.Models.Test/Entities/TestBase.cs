namespace MercurySchool.Models.Test.Entities;

public class TestBase
{
    internal static Person GetTestPerson() => new()
    {
        CreateDate = DateTime.UtcNow,
        Description = "Description of school",
        FirstName = "John",
        Id = Guid.NewGuid(),
        LastName = "Public",
        MiddleName = "Q",
        Name = "Name of person"
    };

    internal static Student GetTestStudent() => new()
    {
        Person = GetTestPerson(),
        StudentAcademicStatus = GetTestStudentAcademicStatus()
    };

    internal static StudentAcademicStatus GetTestStudentAcademicStatus() => new()
    {
        Id = 5,
        Name = "Undetermined",
        Description = "Undetermined"
    };
}