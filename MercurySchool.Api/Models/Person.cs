namespace MercurySchool.Api.Models;

/// <summary>
/// Person
/// </summary>
public class Person : Account
{
    private string _id;
    private string _firstName;
    private string _lastName;

    [SetsRequiredMembers]
    public Person(
        string id,
        string accountId,
        string firstName,
        string lastName) : base(accountId: accountId)
    {
        FirstName = _firstName = firstName;
        LastName = _lastName = lastName;
        Id = _id = id;
        AccountId = accountId;
    }

    /// <summary>
    /// Person's first name
    /// </summary>
    required public string FirstName { get => _firstName; set => _firstName = value; }

    /// <summary>
    /// Person's Id
    /// </summary>
    required public string Id { get => _id; init => _id = value; }

    /// <summary>
    /// Person's last name
    /// </summary>
    required public string LastName { get => _lastName; set => _lastName = value; }

    /// <summary>
    /// Person's middle name (optional)
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// Item type stored in Person database container
    /// </summary>
    public string ItemType => nameof(Person);

    /// <summary>
    /// Person's student record
    /// </summary>
    public Student? Student { get; set; }
}
