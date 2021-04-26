using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Http;

namespace MercurySchool.Functions.Services
{
    public class HttpResponderService : IHttpResponderService
    {
        public HttpResponderService()
        {
        }

        public async Task<HttpResponseData> ProcessRequest(HttpRequestData httpRequest)
        {
            await Task.Yield();

            var response = httpRequest.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}