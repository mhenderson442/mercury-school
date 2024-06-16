using MercurySchool.DataAccess.Factories;

namespace MercurySchool.Test.DataAccess;

public class TestBase
{
    internal static Settings AzureSettings
    {
        get
        {
            var credential = new DefaultAzureCredential();

            var uriString = GetAppConfigEndpoint();
            var appConfigEndpoint = new Uri(uriString);

            IConfiguration config = new ConfigurationBuilder()
            .AddAzureAppConfiguration(options =>
            {
                options.Connect(appConfigEndpoint, credential);
                options.ConfigureKeyVault(vaultOptions => { vaultOptions.SetCredential(credential); });
            })
            .AddUserSecrets("mercury-school-data-access-secrets")
            .Build();

            var settings = config.GetSection("Settings").Get<Settings>();

            if (settings is not null)
            {
                settings.AppConfigurationUriString = uriString;
            }

            return settings!;
        }
    }

    internal static ISqlConnectionFactory InitializeSqlConnectionFactory()
    {
        return new SqlConnectionFactory(AzureSettings);
    }

    internal static String GetAppConfigEndpoint()
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddUserSecrets("mercury-school-secrets")
            .Build();

        return config.GetValue<string>("appConfigEndpoint")!;
    }
}