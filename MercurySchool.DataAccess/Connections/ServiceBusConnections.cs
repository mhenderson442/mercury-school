namespace MercurySchool.DataAccess.Connections;

/// <inheritdoc />
public class ServiceBusConnections(IOptions<AppSettings> options) : IServiceBusConnections
{
    private readonly AppSettings _appSettings = options.Value;

    public string GetServiceBusConnectionString() => _appSettings.ServiceBusSettings.ServiceBusConnectionString;
}