using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Http;

namespace Sample.Sink
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient httpClient;

        public CustomHttpClient() => httpClient = new HttpClient();

        public void Configure(IConfiguration configuration) => httpClient.DefaultRequestHeaders.Add("X-Api-Key", "secret-api-key");

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content) => httpClient.PostAsync(requestUri, content);

        public void Dispose() => httpClient?.Dispose();
    }
}
