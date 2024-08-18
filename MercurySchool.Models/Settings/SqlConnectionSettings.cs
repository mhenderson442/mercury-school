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
    public required String DataSource { get; init; }

    /// <summary>
    /// The user name
    /// </summary>
    public required String UserID { get; init; }

    /// <summary>
    /// The Sql password
    /// </summary>
    public required String Password { get; init; }

    /// <summary>
    /// The SQL Database
    /// </summary>
    public required String InitialCatalog { get; init; }

    /// <summary>
    /// The TrustServerCertificate setting
    /// </summary>
    public required String TrustServerCertificate { get; init; }
}