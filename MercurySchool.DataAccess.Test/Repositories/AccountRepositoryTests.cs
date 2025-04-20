namespace MercurySchool.DataAccess.Test.Repositories;

/// <summary>
/// AccountRepository test class
/// </summary>
public class AccountRepositoryTests : TestBase
{
    [Fact(DisplayName = "GetAccountAsync should return an intance of an account")]
    public async Task GetAccountAsyncReturnsSchool()
    {
        // Arrange
        var sut = await GetAccountRepositoryAsync();
        var id = Guid.Parse("47047d95-e9d9-4901-8218-c6a24ec1c1ed");

        // Act
        var result = await sut.GetAccountAsync(id);

        // Assert
        result.Should().NotBeNull().And.BeAssignableTo<Account>();
    }

    [Fact(DisplayName = "InsertAccountAsyncReturns should return a bool indicating success")]
    public async Task InsertAccountAsyncReturnsBool()
    {
        // Arrange
        var sut = await GetAccountRepositoryAsync();

        var account = GetAccount();

        // Act
        var result = await sut.InsertAccountAsync(account);

        // Assert
        result.Should().BeTrue();
    }
}