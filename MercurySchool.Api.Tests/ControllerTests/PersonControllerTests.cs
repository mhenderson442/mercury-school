namespace MercurySchool.Api.Tests.ControllerTests;

public class PersonControllerTests
{
    /// <summary>
    /// Given an Http Get request
    /// When there are no parmaters
    /// Then a paged response is returned
    /// </summary>
    [Fact(DisplayName = "HTTP Get returns paged response.")]
    public async Task GivenIndexAsyncIsCalled_WhenThereAreNoParameters_ThenAPagedResponseIsReturned()
    {
        // Arrange
        var sut = new PersonController();

        // Act
        var result = await sut.IndexAsync() as OkObjectResult;

        // Assert
        result.Should().BeAssignableTo<IActionResult>();
    }
}