using MercurySchool.DataAccess.Connections;
using MercurySchool.DataAccess.Test.Connections;
using MercurySchool.Models.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MercurySchool.DataAccess.Test;

public class TestBase
{
    internal static async Task<IOptions<AppSettings>> GetAppSettingsOptionsAsync()
    {
        var configuration = new ConfigurationBuilder()
        .AddUserSecrets<SqlDatabaseConnectionTests>()
        .Build();

        var appSettings = new AppSettings
        {
            SqlConnectionSettings = new SqlConnectionSettings
            {
                DataSource = configuration["AppSettings:SqlConnectionSettings:DataSource"]!,
                InitialCatalog = configuration["AppSettings:SqlConnectionSettings:InitialCatalog"]!,
                Password = configuration["AppSettings:SqlConnectionSettings:Password"]!,
                TrustServerCertificate = Convert.ToBoolean(configuration["AppSettings:SqlConnectionSettings:TrustServerCertificate"])!,
                UserID = configuration["AppSettings:SqlConnectionSettings:UserID"]!
            }
        };

        IOptions<AppSettings> options = (IOptions<AppSettings>)Options.Create(appSettings);

        return await Task.FromResult(options);
    }

    internal static async Task<SqlDatabaseConnection> InitializeSqlDatabaseConnectionAsync()
    {
        var options = await GetAppSettingsOptionsAsync();
        return new SqlDatabaseConnection(options);
    }
}