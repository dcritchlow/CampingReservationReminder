using System;
using EventQueryService;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventQueryService = new EventQuery();
            var result = eventQueryService.GetEvents();

            foreach(var calendarEvent in result.Events)
            {
                Console.WriteLine(calendarEvent);
            }
        }
    }
}
