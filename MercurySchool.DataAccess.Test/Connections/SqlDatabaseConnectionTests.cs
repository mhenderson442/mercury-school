using FluentAssertions;
using MercurySchool.DataAccess.Connections;
using MercurySchool.Models.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MercurySchool.DataAccess.Test.Connections;

public class SqlDatabaseConnectionTests
{
    [Fact(DisplayName = "Connection method should return an instance of a SqlConnection")]
    [Trait("Category", "Integration")]
    public void DatabaseFactoryConnectionIsNotNull()
    {
        // Arrange
        IDatabaseConnections sut = InitializeSqlDatabaseConnection();

        // Act
        var connection = sut.Connection;

        // Assert
        connection.Should().NotBeNull().And.BeOfType<SqlConnection>();
    }

    private static SqlDatabaseConnection InitializeSqlDatabaseConnection()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<AppSettings>()
            .Build();

        return new SqlDatabaseConnection(configuration);
    }
}