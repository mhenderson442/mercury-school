using System.Data;

namespace MercurySchool.DataAccess.Connections;

public interface IDatabaseConnections
{
    /// <summary>
    /// Database connection
    /// </summary>
    IDbConnection Connection { get; }
}