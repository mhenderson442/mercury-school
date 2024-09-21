using System.ComponentModel.DataAnnotations;

namespace MercurySchool.Models.Entities;

/// <summary>
/// Bases class
/// </summary>
public class Entity
{
    /// <summary>
    /// Date record was created
    /// </summary>
    public required DateTime CreateDate { get; init; }

    /// <summary>
    /// Description of entity
    /// </summary>
    [MaxLength(256, ErrorMessage = "Name must be between 1 and 256 characters in length")]
    public virtual string? Description { get; set; }

    /// <summary>
    /// Database primary key
    /// </summary>
    [Key]
    public required Guid Id { get; set; }

    /// <summary>
    /// Name of entity
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(32, ErrorMessage = "Name must be between 1 and 32 characters in length")]
    public virtual required string Name { get; set; }
}