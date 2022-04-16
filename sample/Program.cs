using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Sample.Generators;
using Sample.Sink;
using Serilog;

namespace Sample
{
    class Program
    {
        static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>("apiKey", "secret-api-key")
                })
                .Build();

            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Http(
                    requestUri: "http://log-server:5000/log-events",
                    queueLimitBytes: null,
                    httpClient: new CustomHttpClient(),
                    configuration: configuration)
                .CreateLogger()
                .ForContext<Program>();

            var customerGenerator = new CustomerGenerator();
            var orderGenerator = new OrderGenerator();

            while (true)
            {
                var customer = customerGenerator.Generate();
                var order = orderGenerator.Generate();

                logger.Information("{@customer} placed {@order}", customer, order);

                Thread.Sleep(1000);
            }
        }
    }
}
