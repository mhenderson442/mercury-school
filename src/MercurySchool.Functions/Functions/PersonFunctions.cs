using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace MercurySchool.Functions.Functions
{
    public class PersonFunctions
    {
        [Function("GetPersons")]
        public async Task<IActionResult> RunGetPersonsAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestData req, FunctionContext executionContext)
        {
            await Task.Yield();
            return new OkResult();
        }
    }
}