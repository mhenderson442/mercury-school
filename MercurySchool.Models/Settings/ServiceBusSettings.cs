namespace MercurySchool.Models.Settings;

/// <summary>
/// Setting related to service bus interactions
/// </summary>
public class ServiceBusSettings
{
    /// <summary>
    /// The service bus namespace name
    /// </summary>
    public required string Namespace { get; set; }

    /// <summary>
    /// List of queues to be used.
    /// </summary>
    public required string[] Queues { get; set; }

    /// <summary>
    /// The shared access key to the service bus
    /// </summary>
    public required string SharedAccessKey { get; set; }

    /// <summary>
    /// The shared access key name to the service bus
    /// </summary>
    public required string SharedAccessKeyName { get; set; }

    /// <summary>
    /// The connection string to the service bus
    /// </summary>
    public string ServiceBusConnectionString => $"Endpoint=sb://{Namespace};SharedAccessKeyName={SharedAccessKeyName};SharedAccessKey={SharedAccessKey};UseDevelopmentEmulator=true;";
}