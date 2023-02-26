using Microsoft.Azure.Cosmos.Fluent;

namespace MercurySchool.Api.Tests;
public class TestClassBase
{
    public const string MockedAccountId = "156600";

    public static IConfiguration CreateConfiguration()
    {
        var config = new ConfigurationBuilder()

           .AddEnvironmentVariables()
           .AddUserSecrets("mercury-school-secrets")
           .Build();

        return config;
    }

    public static CosmosClient CreateTestCosmosClient()
    {
        var configuration = CreateConfiguration();
        var connectionString = configuration.GetValue<string>("cosmos-connection-string");

        var serializationOptions = CosmosUtilities.CreateCosmosSerializationOptions();

        var cosmosClientBuilder = new CosmosClientBuilder(connectionString)
             .WithSerializerOptions(cosmosSerializerOptions: serializationOptions);

        return cosmosClientBuilder.Build();
    }

    internal static Mock<IPersonRepository> CreateMockPersonRepository() => new();

    internal static Mock<IReferenceDataRepository> CreateMockReferenceDataRepository() => new();

    internal static Mock<IStudentRepository> CreateMockStudentRepository() => new();

    internal static IDataAccessFactory CreateDataAccessFactory()
    {
        var cosmosClient = CreateTestCosmosClient();
        return new DataAccessFactory(cosmosClient);
    }

    internal static Student InitMockedStudent()
    {
        var id = Guid.NewGuid().ToString();
        var student = new Student(id, null);

        return student;
    }
}
