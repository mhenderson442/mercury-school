using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MercurySchool.Functions.Repositories;

namespace MercurySchool.Functions
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.AddJsonFile("appsettings.json", true);
                    configApp.AddJsonFile($"appsettings.{ hostContext.HostingEnvironment.EnvironmentName }.json");
                    configApp.AddEnvironmentVariables();

                    if(hostContext.HostingEnvironment.IsDevelopment()){
                        configApp.AddUserSecrets<Program>();
                    }
                })
                .ConfigureServices(sevices =>
                {
                    sevices.AddScoped<IPersonRepository, PersonRepository>();
                })
                .Build();

            host.Run();
        }
    }
}