namespace MercurySchool.DataAccess.Factories;

public interface ISqlConnectionFactory
{
    /// <summary>
    /// CreateAsync Azure SQL database connection.
    /// </summary>
    /// <returns><see cref="SqlConnection">Instance of SqlConnection</see></returns>
    Task<SqlConnection> CreateAsync();
}