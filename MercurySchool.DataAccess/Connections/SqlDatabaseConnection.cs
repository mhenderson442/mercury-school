using MercurySchool.Models.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace MercurySchool.DataAccess.Connections;

public class SqlDatabaseConnection(IOptions<AppSettings> options) : IDatabaseConnections
{
    private SqlConnection? _connection = null;
    private readonly SqlConnectionSettings _sqlConnectionSettings = options.Value.SqlConnectionSettings;

    public IDbConnection Connection
    {
        get
        {
            if (_connection is not null)
            {
                return _connection;
            }

            var connectionString = GetConnectionString();
            _connection = new SqlConnection(connectionString);

            return _connection;
        }
    }

    private string GetConnectionString()
    {
        var sqlConnnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = _sqlConnectionSettings.DataSource,
            UserID = _sqlConnectionSettings.UserID,
            Password = _sqlConnectionSettings.Password,
            InitialCatalog = _sqlConnectionSettings.InitialCatalog,
            TrustServerCertificate = _sqlConnectionSettings.TrustServerCertificate,
        };

        return sqlConnnectionStringBuilder.ConnectionString;
    }
}