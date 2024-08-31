using System.ComponentModel.DataAnnotations;

namespace MercurySchool.Models.Entities;

public class Entity
{
    /// <summary>
    /// Database primary key
    /// </summary>
    [Key]
    public required Guid Id { get; set; }

    /// <summary>
    /// Name of school
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(32, ErrorMessage = "Name must be between 1 and 32 characters in length")]
    public required string Name { get; set; }

    /// <summary>
    /// Description of school
    /// </summary>
    [MaxLength(256, ErrorMessage = "Name must be between 1 and 256 characters in length")]
    public required string? Description { get; set; }
}