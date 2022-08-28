using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Sample.Generators;
using Sample.Sink;
using Serilog;
using Serilog.Events;

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
                    restrictedToMinimumLevel: LogEventLevel.Information,
                    httpClient: new CustomHttpClient(),
                    queueLimitBytes: null,
                    configuration: configuration)
                .CreateLogger()
                .ForContext<Program>();

            var customerGenerator = new CustomerGenerator();
            var orderGenerator = new OrderGenerator();

            while (true)
            {
                var customer = customerGenerator.Generate();
                var order = orderGenerator.Generate();

                logger.Error("{@customer} placed {@order}", customer, order);

                Thread.Sleep(1000);
            }
        }
    }
}
