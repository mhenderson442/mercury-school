namespace MercurySchool.Models.Settings;

/// <summary>
/// The Application settings
/// </summary>
public class AppSettings
{
    /// <summary>
    /// Then SQL Server connection settings
    /// </summary>
    public required SqlConnectionSettings SqlConnectionSettings { get; init; }
}