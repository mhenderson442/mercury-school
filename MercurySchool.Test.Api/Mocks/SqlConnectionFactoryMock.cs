namespace MercurySchool.Test.Api.Mocks;

public class SqlConnectionFactoryMock : ISqlConnectionFactory
{
    public async Task<SqlConnection> CreateAsync()
    {
        await Task.Yield();
        var sqlConnection = new Mock<SqlConnection>();

        return sqlConnection.Object;
    }
}