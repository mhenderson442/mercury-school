namespace MercurySchool.Models.Entities;
public record School
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Name of school
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Description of school
    /// </summary>
    public string? Description { get; init; }
}