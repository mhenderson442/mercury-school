namespace MercurySchool.Test.Api.Mocks;

internal class AzureCredentialMock : TokenCredential
{
    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        // You can customize the token response here.
        var accessToken = Guid.NewGuid().ToString();
        var expiresOn = DateTimeOffset.UtcNow.AddHours(1);

        return new AccessToken(accessToken, expiresOn);
    }

    public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) => new(GetToken(requestContext, cancellationToken));
}