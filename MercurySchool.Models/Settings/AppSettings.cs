namespace MercurySchool.Models.Settings;

/// <summary>
/// The Application settings
/// </summary>
public class AppSettings
{
    /// <summary>
    /// The SQL Server connection settings
    /// </summary>
    public required SqlConnectionSettings SqlConnectionSettings { get; init; }

    /// <summary>
    /// Service bus settings
    /// </summary>
    public required ServiceBusSettings ServiceBusSettings { get; init; }
}