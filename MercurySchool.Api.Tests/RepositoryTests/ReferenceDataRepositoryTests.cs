namespace MercurySchool.Api.Tests.RepositoryTests;
public class ReferenceDataRepositoryTests : TestClassBase
{
    [Fact(DisplayName = "Get reference data returns list")]
    [Trait("Category", "Integration")]
    public async Task GetReferenceDataReturnsList()
    {
        // Arrange
        IReferenceDataRepository sut = await CreateReferenceDataRepository();

        // Act
        var result = await sut.GetReferenceDataAsync(Constants.ReferenceDataTypes.AcademicStatus);

        // Assert
        result.Should()
            .NotBeNull()
            .And.BeAssignableTo<List<string>>();

        result.Capacity.Should().BeGreaterThan(0, "Item capacity is not greater than 0.");

    }

    private static async Task<IReferenceDataRepository> CreateReferenceDataRepository()
    {
        await Task.Yield();
        var databaseAccessFactory = CreateDataAccessFactory();
        return new ReferenceDataRepository(databaseAccessFactory);
    }
}
