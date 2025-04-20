namespace MercurySchool.DataAccess.Connections;

/// <summary>
/// Interface for database connections.
/// </summary>
public interface IDatabaseConnections
{
    /// <summary>
    /// Database connection
    /// </summary>
    IDbConnection Connection { get; }
}