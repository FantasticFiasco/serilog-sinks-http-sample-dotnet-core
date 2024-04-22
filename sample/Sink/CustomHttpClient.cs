using System.IO;
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

        public void Configure(IConfiguration configuration) => httpClient.DefaultRequestHeaders.Add("X-Api-Key", configuration["apiKey"]);

        public async Task<HttpResponseMessage> PostAsync(string requestUri, Stream contentStream, CancellationToken cancellationToken)
        {
            using var content = new StreamContent(contentStream);
            content.Headers.Add("Content-Type", "application/json");

            var response = await httpClient
                .PostAsync(requestUri, content, cancellationToken)
                .ConfigureAwait(false);

            return response;
        }

        public void Dispose() => httpClient?.Dispose();
    }
}
