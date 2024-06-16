namespace MercurySchool.Models;
public record PatchRequest<T>
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public required Guid Id { get; set; }

    /// <summary>
    /// Name of the property to be patched.
    /// </summary>
    public required string PropertyName { get; set; }

    /// <summary>
    /// Value of property to be patched.
    /// </summary>
    public required T PropertyValue { get; set; }
}