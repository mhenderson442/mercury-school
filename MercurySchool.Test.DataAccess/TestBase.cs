namespace MercurySchool.Test.DataAccess;

public class TestBase
{
    //internal static IOptions<Settings> CreateSettingsOptions()
    //{
    //    var settings = AzureSettings;
    //    return Options.Create(settings);
    //}

    internal static Settings AzureSettings
    {
        get
        {
            var credential = new DefaultAzureCredential();
            var appConfigEndpoint = new Uri(LocalSettings.AppConfigurationUriString!);

            IConfiguration config = new ConfigurationBuilder()
            .AddAzureAppConfiguration(options =>
            {
                options.Connect(appConfigEndpoint, credential);
                options.ConfigureKeyVault(vaultOptions => { vaultOptions.SetCredential(credential); });
            })
            .Build();

            var settings = config.GetSection("WebApp:LocalSettings").Get<Settings>();

            return settings!;
        }
    }

    internal static Settings LocalSettings
    {
        get
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets("mercury-school-data-access-secrets")
                .Build();

            var settings = new Settings
            {
                SqlDataSource = config.GetValue<string>("SqlDataSource")!,
                SqlInitialCatalog = config.GetValue<string>("SqlInitialCatalog")!,
                SqlPassword = config.GetValue<string>("SqlPassword")!,
                SqlUserId = config.GetValue<string>("SqlUserId")!,
                AppConfigurationUriString = config.GetValue<string>("AppConfigurationUriString")!
            };

            return settings;
        }
    }

    internal static ISqlConnectionFactory InitializeSqlConnectionFactory(bool useAzureSettings = false)
    {
        var settings = useAzureSettings ? AzureSettings : LocalSettings;
        return new SqlConnectionFactory(settings);
    }
}