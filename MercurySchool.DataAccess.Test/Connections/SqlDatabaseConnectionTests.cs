using FluentAssertions;
using MercurySchool.DataAccess.Connections;
using MercurySchool.Models.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MercurySchool.DataAccess.Test.Connections;

public class SqlDatabaseConnectionTests : TestBase
{
    [Fact(DisplayName = "Connection method should return an instance of a SqlConnection")]
    [Trait("Category", "Integration")]
    public async Task DatabaseFactoryConnectionIsNotNull()
    {
        // Arrange
        IDatabaseConnections sut = await InitializeSqlDatabaseConnectionAsync();

        // Act
        var connection = sut.Connection;
        connection.Open();

        // Assert
        connection.Should().NotBeNull().And.BeOfType<SqlConnection>();
        connection.State.Should().Be(System.Data.ConnectionState.Open);

        connection.Close();
    }
}