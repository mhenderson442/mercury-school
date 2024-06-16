namespace MercurySchool.DataAccess.Factories;

public class SqlConnectionFactory(Settings settings) : ISqlConnectionFactory
{
    private readonly Settings _settings = settings;

    /// <inheritdoc />
    public async Task<SqlConnection> CreateAsync()
    {
        await Task.Yield();
        var connectionString = CreateAzureConnectionString();
        return new SqlConnection(connectionString);
    }

    /// <summary>
    /// Build connection string.
    /// </summary>
    /// <returns>Azure SQL database connection string.</returns>
    private string CreateAzureConnectionString()
    {
        var builder = new SqlConnectionStringBuilder
        {
            Authentication = SqlAuthenticationMethod.ActiveDirectoryDefault,
            ConnectTimeout = 30,
            DataSource = _settings.SqlDataSource,
            InitialCatalog = _settings.SqlInitialCatalog,
            Encrypt = true,
            PersistSecurityInfo = false,
            MultipleActiveResultSets = false,
            TrustServerCertificate = false,
        };

        return builder.ConnectionString;
    }
}