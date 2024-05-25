namespace MercurySchool.DataAccess;

public class SqlConnectionFactory(Settings settings) : ISqlConnectionFactory
{
    private readonly Settings _settings = settings;

    /// <inheritdoc />
    public async Task<SqlConnection> CreateAsync(bool useAzureConnection = false)
    {
        await Task.Yield();
        var connectionString = useAzureConnection ? CreateAzureConnectionString() : CreateLocalConnectionString();
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

    /// <summary>
    /// Build connection string.
    /// </summary>
    /// <returns>Local SQL database connection string.</returns>
    private string CreateLocalConnectionString()
    {
        var builder = new SqlConnectionStringBuilder
        {
            Authentication = SqlAuthenticationMethod.SqlPassword,
            UserID = _settings.SqlUserId,
            Password = _settings.SqlPassword,
            ConnectTimeout = 30,
            DataSource = _settings.SqlDataSource,
            InitialCatalog = _settings.SqlInitialCatalog,
            Encrypt = false,
            PersistSecurityInfo = false,
            MultipleActiveResultSets = false,
            TrustServerCertificate = false,
        };

        return builder.ConnectionString;
    }
}