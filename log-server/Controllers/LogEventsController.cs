using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    public class LogEventsController : ControllerBase
    {
        private readonly ILogger<LogEventsController> logger;

        public LogEventsController(ILogger<LogEventsController> logger)
        {
            this.logger = logger;
        }

        [HttpPost("log-events")]
        public void Post([FromBody] LogEvent[] body)
        {
            var nbrOfEvents = body.Length;
            var apiKey = Request.Headers["X-Api-Key"].FirstOrDefault();

            logger.LogInformation(
                "Received batch of {count} log events from {sender}",
                nbrOfEvents,
                apiKey);

            foreach (var logEvent in body)
            {
                logger.LogInformation("Message: {message}", logEvent.RenderedMessage);
            }
        }
    }
}
