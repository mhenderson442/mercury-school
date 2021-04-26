using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MercurySchool.Functions.Repositories;
using System.Threading.Tasks;

namespace MercurySchool.Functions
{
    public class Program
    {
        public static async Task Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    _ = configApp.AddJsonFile("appsettings.json", true);
                    _ = configApp.AddJsonFile($"appsettings.{ hostContext.HostingEnvironment.EnvironmentName }.json");
                    _ = configApp.AddEnvironmentVariables();

                    if (hostContext.HostingEnvironment.IsDevelopment())
                    {
                        _ = configApp.AddUserSecrets<Program>();
                    }
                })
                .ConfigureServices(sevices =>
                {
                    _ = sevices.AddScoped<IPersonRepository, PersonRepository>();
                })
                .Build();

            await host.RunAsync();
        }
    }
}