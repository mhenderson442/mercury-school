using MercurySchool.DataAccess;
using MercurySchool.DataAccess.Factories;

namespace MercurySchool.Test.Api;

public class TestBase
{
    public const string SchoolId = "09CDDA84-A34B-4394-A6B3-8D1D8636B88D";

    internal static IOptions<Settings> CreateSettingsOptions()
    {
        var settings = InitializeSettings();
        return Options.Create(settings);
    }

    internal static Settings InitializeSettings()
    {
        var credential = new DefaultAzureCredential();
        var appConfigUriString = "https://mercury-school-app-config.azconfig.io";
        var appConfigEndpoint = new Uri(appConfigUriString!);

        IConfiguration config = new ConfigurationBuilder()
        .AddAzureAppConfiguration(options =>
        {
            options.Connect(appConfigEndpoint, credential);
            options.ConfigureKeyVault(vaultOptions => { vaultOptions.SetCredential(credential); });
        })
        .Build();

        var settings = config.GetSection("WebApp:Settings").Get<Settings>();

        return settings!;
    }

    internal static ISqlConnectionFactory InitializeSqlConnectionFactory()
    {
        var settings = InitializeSettings();
        return new SqlConnectionFactory(settings);
    }

    internal static Stream InitializeMockPatchRequestStream(string id)
    {
        var patchRequest = new PatchRequest<string> { Id = Guid.NewGuid(), PropertyName = id, PropertyValue = "Test Patch" };
        var patchRequestSerialized = JsonSerializer.Serialize(patchRequest);
        var buffer = Encoding.UTF8.GetBytes(patchRequestSerialized);

        using var stream = new MemoryStream(buffer);

        return stream;
    }
}