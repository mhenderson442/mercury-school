namespace MercurySchool.Api.Extensions;

public static class DependencyInjection
{
    /// <summary>
    /// Add application configuration items.
    /// <para>Security principle should have <strong>App Configuration Data Reader</strong> and <strong>Key Vault Secrets User</strong> assigned</para>
    /// </summary>
    /// <param name="manager"><see cref="ConfigurationManager">ConfigurationManager</see></param>
    /// <param name="credential"><see cref="DefaultAzureCredential">Security principle should have <strong>App Configuration Data Reader</strong> assigned</see></param>
    public static void AddAppConfigurations(this ConfigurationManager manager, DefaultAzureCredential credential)
    {
        var appConfigUriString = manager["appConfigEndpoint"];
        var appConfigEndpoint = new Uri(appConfigUriString!);

        _ = manager.AddAzureAppConfiguration(configBuilder =>
        {
            configBuilder.Connect(appConfigEndpoint, credential);
            configBuilder.ConfigureKeyVault(vaultOptions => { vaultOptions.SetCredential(credential); });
        });
    }

    /// <summary>
    /// Add service and other dependency injection related objects.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection">Service collection</see></param>
    /// <param name="credential"><see cref="DefaultAzureCredential">DefaultAzureCredential</see></param>
    /// <param name="settings"><see cref="Settings">Configuration data derived from application configuration</see></param>
    public static void AddAppServices(this IServiceCollection services, DefaultAzureCredential credential, Settings settings)
    {
        _ = services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

        _ = services.AddScoped<ISchoolsService, SchoolsService>();
        _ = services.AddScoped<IPersonsService, PersonsService>();

        _ = services.AddScoped<ISchoolsRepository, SchoolsRepository>();
        _ = services.AddScoped<IPersonsRepository, SchoolsRepository>();

        services.AddAzureClients(clientBuilder =>
        {
            clientBuilder.UseCredential(credential);
        });

        _ = services.AddSingleton(settings!);

        _ = services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
        {
            options.SerializerOptions.PropertyNameCaseInsensitive = true;
            options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });

        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen();
    }
}