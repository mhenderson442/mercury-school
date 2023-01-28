using Microsoft.Azure.Cosmos.Fluent;

namespace MercurySchool.Api.Tests;
public class TestClassBase
{
    public const string MockedAccountId = "156600";


    public static IConfiguration CreateConfiguration()
    {
        var vaultUri = new Uri("https://mercury-vault-mfygi.vault.azure.net/");

        var config = new ConfigurationBuilder()

           .AddEnvironmentVariables()
           .AddJsonFile($"{Environment.CurrentDirectory}/settings.json")
           .AddAzureKeyVault(vaultUri, new DefaultAzureCredential())
           .Build();

        return config;
    }

    public static CosmosClient CreateTestCosomosClient()
    {
        var configuration = CreateConfiguration();
        var connectionString = configuration.GetValue<string>("AppSettings:CosmosConnectionString");

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
        var cosmosClient = CreateTestCosomosClient();
        return new DataAccessFactory(cosmosClient);
    }

    internal static Student InitMockedStudent()
    {
        var id = Guid.NewGuid().ToString();
        var student = new Student(id);

        return student;
    }
}
