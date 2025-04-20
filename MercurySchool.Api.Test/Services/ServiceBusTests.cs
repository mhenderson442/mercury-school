namespace MercurySchool.Api.Test.Services;

public class ServiceBusTest : TestBase
{
    [Fact]
    public async Task EnqueueMessage_ShouldSucceed()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();

        var scope = application.Services.CreateScope();
        var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

        var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
        var queueName = appSettings?.ServiceBusSettings.Queues.FirstOrDefault();

        var serviceBusClient = scope.ServiceProvider.GetRequiredService<ServiceBusClient>();

        var sender = serviceBusClient.CreateSender(queueName);
        var testMessage = new ServiceBusMessage("Test message content");

        // Act
        Func<Task> act = async () => await sender.SendMessageAsync(testMessage);

        // Assert
        await act.Should().NotThrowAsync(); // Ensure no exception is thrown
    }
}