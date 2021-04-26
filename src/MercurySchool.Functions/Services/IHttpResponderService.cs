using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Http;

namespace MercurySchool.Functions.Services
{
    public interface IHttpResponderService
    {
        Task<HttpResponseData> ProcessRequest(HttpRequestData httpRequest);
    }
}