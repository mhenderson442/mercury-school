using MercurySchool.Models.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace MercurySchool.DataAccess.Connections;

public class SqlDatabaseConnection(IConfiguration _configuration) : IDatabaseConnections
{
    private SqlConnection? _Connection = null;

    public IDbConnection Connection
    {
        get
        {
            if (_Connection is not null)
            {
                return _Connection;
            }

            var connectionString = GetConnectionString();
            _Connection = new SqlConnection(connectionString);

            return _Connection;
        }
    }

    private string GetConnectionString()
    {
        var appSettings = _configuration["AppSettings:SqlConnectionSettings:UserID"];

        var sqlConnnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = "localhost",
            UserID = "api_login",
            Password = "CtUy^17u2qXf!QmnG#RaaDqwFu5bg^W2",
            InitialCatalog = "MercurySchool",
            TrustServerCertificate = true,
        };

        return sqlConnnectionStringBuilder.ConnectionString;
    }
}