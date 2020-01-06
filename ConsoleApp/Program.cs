using System;
using EventQueryService;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventQueryService = new EventQuery();
            var eventsList = eventQueryService.GetEvents();

            foreach(var calendarEvent in eventsList)
            {
                Console.WriteLine(calendarEvent);
            }
        }
    }
}
