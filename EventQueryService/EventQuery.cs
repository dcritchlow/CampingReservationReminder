using System;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using EventQueryService.DTO;
using System.Collections.Generic;

namespace EventQueryService
{
    public class EventQuery
    {
        public IEnumerable<CalendarEvent> GetEvents()
        {
            var credential = new CalendarCredential().GetCredential();
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = Constants.ApplicationName,
            });

            EventsResource.ListRequest request = service.Events.List(Constants.CampingCalendarId);
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 20;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            Events events = request.Execute();

            var eventList = new CalendarEvents().Items(events);
            return eventList;
        }
    }
}
