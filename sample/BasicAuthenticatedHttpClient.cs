using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Serilog.Sinks.Http;

namespace Sample
{
    public class BasicAuthenticatedHttpClient : IHttpClient
    {
        private readonly HttpClient client;
        
        public BasicAuthenticatedHttpClient(string username, string password)
        {
            if (username == null) throw new ArgumentNullException(nameof(username));
            if (password == null) throw new ArgumentNullException(nameof(password));
            
            client = CreateHttpClient(username, password);
        }

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content) =>
            client.PostAsync(requestUri, content);

        public void Dispose() =>
            client.Dispose();
        
        private static HttpClient CreateHttpClient(string username, string password)
        {
            var client = new HttpClient();

            var schema = "Basic";
            var parameter = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(schema, parameter);
    
            return client;
        }
    }
}
