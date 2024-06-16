namespace MercurySchool.Test.Api.Mocks;

public class WebApplicationFactoryMock<TStartup> : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var credential = new AzureCredentialMock();

        builder.ConfigureServices(services =>
        {
            services.AddScoped<IPersonsService, PersonsServiceMock>();
            services.AddScoped<ISchoolsService, SchoolsServiceMock>();

            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactoryMock>();

            services.AddAzureClients(clientBuilder =>
            {
                clientBuilder.UseCredential(credential);
            });
        });
    }
}