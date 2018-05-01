using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace LogServer.Controllers
{
    public class LogEventsController : Controller
    {
        [HttpPost("log-events")]
        public void Post([FromBody] LogEvents body)
        {
            Console.WriteLine("Received batch of log events");
            Console.WriteLine("================================================================================");
            Console.WriteLine($"API Key:\t{Request.Headers["X-Api-Key"].FirstOrDefault()}");
            Console.WriteLine($"Nbr of events:\t{body.Events.Length}");
            Console.WriteLine("Events:");

            foreach (var logEvent in body.Events)
            {
                Console.WriteLine($"\t\t{logEvent.Timestamp} [{logEvent.Level}] {logEvent.RenderedMessage}");
            }

            Console.WriteLine(string.Empty);
        }
    }
}
