using MercurySchool.DataAccess.Connections;
using MercurySchool.DataAccess.Repositories;
using MercurySchool.Models.Settings;

namespace MercurySchool.Api.Extensions;

public static class ServiceRegistrations
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

        builder.Services.AddScoped<IDatabaseConnections, SqlDatabaseConnection>();
        builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
        builder.Services.AddOptions<AppSettings>().Bind<AppSettings>(builder.Configuration.GetSection("AppSettings"));

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}