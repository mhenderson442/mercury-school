using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using MercurySchool.Functions.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Moq;
using Xunit;

namespace MercurySchool.Functions.UnitTests.ServiceTests
{
    public class HttpResponderServiceTests
    {
        public HttpResponderServiceTests()
        {
            HttpResponderService = new HttpResponderService();
        }

        public IHttpResponderService HttpResponderService { get; init; }

        [Fact(DisplayName = "Process request should return an instance of HttpResultData")]
        public async Task ProcessRequestShouldReturnHttpResultData()
        {
            // Arrange
            var httpRequest = new Mock<HttpRequestData>();
            httpRequest.Setup(x => x.Body).Returns(It.IsAny<MemoryStream>());

            // Act
            var sut = await HttpResponderService.ProcessRequest(httpRequest.Object);

            // Assert
            _ = sut.Should()
                .NotBeNull("should not be null");

            _ = sut.StatusCode.Should()
                .Be(HttpStatusCode.OK, "status code should be OK");

        }
    }
}