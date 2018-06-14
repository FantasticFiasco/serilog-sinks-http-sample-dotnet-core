using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogServer.Controllers
{
    public class LogEventsController : Controller
    {
        private readonly ILogger<LogEventsController> logger;

        public LogEventsController(ILogger<LogEventsController> logger)
        {
            this.logger = logger;
        }

        [HttpPost("log-events")]
        public void Post([FromBody] LogEvents body)
        {
            var nbrOfEvents = body.Events.Length;
            var apiKey = Request.Headers["X-Api-Key"].FirstOrDefault();
            
            logger.LogInformation(
                "Received batch of {count} log events from {sender}",
                nbrOfEvents,
                apiKey);
            
            foreach (var logEvent in body.Events)
            {
                logger.LogInformation("Message: {message}", logEvent.RenderedMessage);
            }
        }
    }
}
