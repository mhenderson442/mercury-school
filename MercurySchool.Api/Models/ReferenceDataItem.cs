namespace MercurySchool.Api.Models;

/// <summary>
/// Reference Data Item
/// </summary>
/// <value></value>
public record ReferenceDataItem
{
    /// <summary>
    /// Name
    /// </summary>
    /// <value></value>
    required public string Name { get; init; }
    
    /// <summary>
    /// Reference data type.
    /// </summary>
    /// <value></value>
    required public string Type { get; init; }
}
