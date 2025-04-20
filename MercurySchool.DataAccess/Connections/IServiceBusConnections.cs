namespace MercurySchool.DataAccess.Connections;

/// <summary>
/// Interface for service bus connections.
/// </summary>
public interface IServiceBusConnections
{
    /// <summary>
    /// Get the connection string for the service bus.
    /// </summary>
    /// <returns></returns>
    string GetServiceBusConnectionString();
}