namespace MercurySchool.Api.Tests.FactoryTests;
public class DatabaseConnectionFactoryTests : TestClassBase
{
    [Fact]
    [Trait("Category", "Integration")]
    public async Task GetPersonContainerAsyncContainer()
    {
        // Arrange
        var sut = CreateDataAccessFactory();

        // Act
        var result = await sut.GetPersonContainerAsync();

        // Assert
        result.Should().BeAssignableTo<Container>();
    }

    [Fact]
    [Trait("Category", "Integration")]
    public async Task GetReferenceDataContainerAsyncContainer()
    {
        // Arrange
        var sut = CreateDataAccessFactory();

        // Act
        var result = await sut.GetReferenceDataContainerAsync();

        // Assert
        result.Should().BeAssignableTo<Container>();
    }


}
