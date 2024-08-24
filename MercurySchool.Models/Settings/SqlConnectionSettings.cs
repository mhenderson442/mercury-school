using System.Globalization;

namespace MercurySchool.Models.Settings;

/// <summary>
/// Setting for building a Sql Connection string
/// </summary>
public class SqlConnectionSettings
{
    /// <summary>
    /// The SQL server
    /// </summary>
    public required string DataSource { get; init; }

    /// <summary>
    /// The user name
    /// </summary>
    public required string UserID { get; init; }

    /// <summary>
    /// The Sql password
    /// </summary>
    public required string Password { get; init; }

    /// <summary>
    /// The SQL Database
    /// </summary>
    public required string InitialCatalog { get; init; }

    /// <summary>
    /// The TrustServerCertificate setting
    /// </summary>
    public required bool TrustServerCertificate { get; init; }
}