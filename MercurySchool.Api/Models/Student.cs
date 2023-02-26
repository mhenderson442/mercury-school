using System.Diagnostics;

namespace MercurySchool.Api.Models;

/// <summary>
/// Student record
/// </summary>
/// <param name="Id">Student Id</param>
/// <param name="AcademicStatus">Academic Status</param>
/// <returns>Student</returns>
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public record Student(string Id, string? AcademicStatus)
{
    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}