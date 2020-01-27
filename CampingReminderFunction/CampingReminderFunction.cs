using System;
using EventQueryService;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CampingReminderFunction
{
    public static class CampingReminderFunction
    {
        [FunctionName("CampingReminderFunction")]
        public static void Run([TimerTrigger("0 */1 7-17 * * *")]TimerInfo myTimer, ILogger log)
        {
            var calendarEvents = new EventQuery().GetEvents();
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        }
    }
}
