namespace MercurySchool.Test.Api.Enpoints;

public class EndpointTestBase(WebApplicationFactoryMock<Program> webApplicationFactoryMock)
{
    internal readonly WebApplicationFactoryMock<Program> _webApplicationFactoryMock = webApplicationFactoryMock;

    internal static JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
}