using System.ComponentModel.DataAnnotations;

namespace MercurySchool.Models.Entities;

/// <summary>
/// School
/// </summary>
public class School() : Entity<Guid>
{
    /// <summary>
    /// Date record was created
    /// </summary>
    public required DateTime CreateDate { get; init; }
}