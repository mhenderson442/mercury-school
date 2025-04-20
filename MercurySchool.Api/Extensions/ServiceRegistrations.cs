namespace MercurySchool.Api.Extensions;

public static class ServiceRegistrations
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<AppSettings>(options =>
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets<Program>();
            }

            builder.Configuration.GetSection("AppSettings").Bind(options);
        });

        builder.Services.AddSingleton<ServiceBusClient>(s =>
        {
            var serviceBusSettings = builder.Configuration.GetSection("AppSettings:ServiceBusSettings").Get<ServiceBusSettings>()!;
            return new ServiceBusClient(serviceBusSettings.ServiceBusConnectionString);
        });

        builder.Services.AddScoped<IDatabaseConnections, SqlDatabaseConnection>();
        builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}