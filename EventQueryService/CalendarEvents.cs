using System.Linq;
using Google.Apis.Calendar.v3.Data;
using EventQueryService.DTO;
using System.Collections.Generic;
using System;

namespace EventQueryService
{
    public class CalendarEvents
    {
        public IEnumerable<CalendarEvent> Items(Events events)
        {
            if (events.Items == null && events.Items.Count == 0)
            {
                return Enumerable.Empty<CalendarEvent>();
            }

            var calendarEventList = new List<CalendarEvent>();
            foreach (var eventItem in events.Items)
            {
                if (!eventItem.Summary.ToLower().Contains("camping"))
                {
                    continue;
                }

                var startDate = eventItem.Start.DateTime?.ToString("MM/dd") ?? DateTime.Parse(eventItem.Start.Date).ToString("MM/dd").Replace(" ", "");
                var endDate = eventItem.End.DateTime?.ToString("MM/dd") ?? DateTime.Parse(eventItem.End.Date).ToString("MM /dd").Replace(" ", "");
                var campType = eventItem.Description.GetCampType();
                var website = eventItem.Description.GetWebsite();
                var campers = eventItem.Description.GetCampers();
                
                var calendarEvent = new CalendarEvent
                {
                    Summary = eventItem.Summary.GetDisplayTitle(),
                    Start = startDate,
                    StartDateTime = eventItem.Start.DateTime ?? DateTime.Parse(eventItem.Start.Date),
                    End = endDate,
                    EndDateTime = eventItem.End.DateTime ?? DateTime.Parse(eventItem.End.Date),
                    CampType = campType,
                    Website = website,
                    Campers = campers,
                };
                calendarEventList.Add(calendarEvent);
            }
            return calendarEventList;
        }
    }
}
