using System;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Sample.Generators;
using Serilog;

namespace Sample
{
    class Program
    {
        static void Main()
        {
            ILogger logger = new LoggerConfiguration()
                .WriteTo.DurableHttp(
                    "http://log-server:5000/log-events",
                    httpClient: new BasicAuthenticatedHttpClient("User1", "SecretPassword!"))
                .CreateLogger()
                .ForContext<Program>();

            Serilog.Debugging.SelfLog.Enable(message => Console.WriteLine("Serilog SelfLog: " + message));
            
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
