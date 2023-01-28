namespace MercurySchool.Api.Models;

public record ReferenceDataItem
{
    required public string Name { get; init; }
    required public string Type { get; init; }
}
