namespace MercurySchool.Models.Entities;

/// <summary>
/// An instance of a person
/// </summary>
public class Person : Entity<Guid>
{
    /// <summary>
    /// Date record was created
    /// </summary>
    public required DateTime CreateDate { get; init; }

    /// <summary>
    /// The person's first name
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// The persons's last name
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// The middle name
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// Name of person
    /// </summary>
    public override required string Name
    {
        get => base.Name;
        set => base.Name = $"{FirstName} {LastName}";
    }
}