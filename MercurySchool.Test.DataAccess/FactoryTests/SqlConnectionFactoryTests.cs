namespace MercurySchool.Test.DataAccess.FactoryTests;

public class SqlConnectionFactoryTests : TestBase
{
    [Fact]
    public async Task CreateSqlConnectionShouldReturnObject()
    {
        // Arrange
        var sut = InitializeSqlConnectionFactory();

        // Act
        var result = await sut.CreateAsync();

        // Assert
        result.Should().BeAssignableTo<SqlConnection>();

        await result.OpenAsync();
        result.State.Should().Be(System.Data.ConnectionState.Open);
        await result.CloseAsync();
    }
}