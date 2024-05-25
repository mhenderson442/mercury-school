namespace MercurySchool.DataAccess;

public interface ISqlConnectionFactory
{
    /// <summary>
    /// CreateAsync Azure SQL database connection.
    /// </summary>
    /// <param name="useAzureConnection">Indicate whether to Azure settings.</param>
    /// <returns></returns>
    Task<SqlConnection> CreateAsync(bool useAzureConnection = false);
}