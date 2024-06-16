namespace MercurySchool.Models.Entities;

/// <summary>
/// Person record
/// </summary>
public record Person
{
    /// <summary>
    /// First Name
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Unique identifier
    /// </summary>
    public required Guid Id { get; set; }

    /// <summary>
    /// Last Name
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Middle Name
    /// </summary>
    public string? MiddleName { get; set; } = null;
}