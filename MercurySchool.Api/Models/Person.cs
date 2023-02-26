using System.Diagnostics;

namespace MercurySchool.Api.Models;

/// <summary>
/// Person record
/// </summary>
/// <param name="AccountId">Account Id</param>
/// <returns>Person</returns>
public record Person(string AccountId) : Account(AccountId)
{
    /// <summary>
    /// Id
    /// </summary>
    /// <value></value>
    public required string Id { get; init; }

    /// <summary>
    /// First Name
    /// </summary>
    /// <value>First Name</value>
    public required string FirstName { get; init; }

    /// <summary>
    /// Middle Name
    /// </summary>
    /// <value>Middle Name</value>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? MiddleName { get; init; }

    /// <summary>
    /// Last Name
    /// </summary>
    /// <value>Last Name</value>
    public required string LastName { get; init; }

    /// <summary>
    /// Student
    /// </summary>
    /// <value>Student</value>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull )]
    public Student? Student { get; init; }
}