namespace MercurySchool.Api.Test;

public class TestBase
{
    /// <summary>
    /// Mocked options for dependency injection.
    /// </summary>
    /// <returns><see cref="IOptions{T}"/></returns>
    internal static async Task<IOptions<AppSettings>> GetAppSettingsOptionsAsync()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<TestBase>()
            .Build();

        var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

        return appSettings is null
            ? throw new InvalidOperationException("AppSettings configuration is missing or invalid.")
            : await Task.FromResult(Options.Create(appSettings));
    }

    internal static async Task<IConfigurationRoot> GetConfigurationRoot()
    {
        var configuration = new ConfigurationBuilder()
        .AddUserSecrets<TestBase>()
        .Build();

        return await Task.FromResult(configuration);
    }
}