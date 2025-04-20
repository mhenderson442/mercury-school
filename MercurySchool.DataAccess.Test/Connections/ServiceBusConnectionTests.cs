namespace MercurySchool.DataAccess.Test.Connections;

/// <summary>
/// Test class for <see cref="ServiceBusConnections"/>
/// </summary>
public class ServiceBusConnectionTests : TestBase
{
    [Fact(DisplayName = "Service Bus connection succeeds.")]
    public async Task ServiceBusConnectionSucceeds()
    {
        // Arrange
        var sut = await GetServiceBusConnectionAsync();

        // Act
        var result = sut.GetServiceBusConnectionString();

        // Assert
        result.Should().NotBeNullOrEmpty();
    }

    /// <summary>
    /// Mocked instance of <see cref="IServiceBusConnections"/>
    /// </summary>
    /// <returns>An implmentation of <see cref="IServiceBusConnections"/></returns>
    private static async Task<IServiceBusConnections> GetServiceBusConnectionAsync()
    {
        var options = await GetAppSettingsOptionsAsync();
        return new ServiceBusConnections(options);
    }
}