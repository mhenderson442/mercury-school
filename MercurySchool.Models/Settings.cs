namespace MercurySchool.Models;

public class Settings
{
    /// <summary>
    /// Azure SQL Database server
    /// </summary>
    public required string SqlDataSource { get; init; }

    /// <summary>
    /// Azure SQL Database name
    /// </summary>
    public required string SqlInitialCatalog { get; init; }

    /// <summary>
    /// Application Configuration Service Uri
    /// </summary>
    public string? AppConfigurationUriString { get; set; }
}