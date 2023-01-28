namespace MercurySchool.Api.Utilities;

internal static class CosmosUtilities
{
    public static CosmosSerializationOptions CreateCosmosSerializationOptions()
    {
        var serializationOptions = new CosmosSerializationOptions
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
        };

        return serializationOptions;
    }
}
