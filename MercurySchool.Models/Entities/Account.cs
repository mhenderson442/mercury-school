namespace MercurySchool.Models.Entities;

/// <summary>
/// Account class
/// </summary>
public class Account : Entity<Guid>
{
    /// <summary>
    /// Date record was created
    /// </summary>
    public required DateTime CreateDate { get; init; }
}