using System;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using EventQueryService.DTO;
using Google.Apis.Auth.OAuth2;
using EventQueryService.AvailableWeekends;

namespace EventQueryService
{
    public class EventQuery
    {
        public EventQueryResult GetEvents()
        {
            var scopes = new []{  
                CalendarService.Scope.Calendar,  
                CalendarService.Scope.CalendarEvents,  
                CalendarService.Scope.CalendarEventsReadonly  
            }; 
            
            var value = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            var credential = GoogleCredential
                .GetApplicationDefault()
                .CreateScoped(scopes);
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
            var weekends = new FridayToSundayWeekend().Weekends();
            var approvedCampers = new ApprovedCampers().List;
            var result = new EventQueryResult
            {
                Events = eventList,
                Weekends = weekends,
                ApprovedCampers = approvedCampers
            };
            return result;
        }
    }
}
