namespace MercurySchool.Models.Entities;

/// <summary>
/// An instance of a person
/// </summary>
public class Person : Entity
{
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

    public override required string Name
    {
        get => base.Name;
        set => base.Name = $"{FirstName} {LastName}";
    }
}