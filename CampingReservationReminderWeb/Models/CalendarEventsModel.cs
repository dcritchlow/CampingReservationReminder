using System.Collections.Generic;
using EventQueryService.DTO;

namespace CampingReservationReminderWeb.Models
{
    public class CalendarEventsModel
    {
        public IEnumerable<CalendarEvent> CalendarEvents { get; }
        public IEnumerable<Camper> Campers { get; }
        public List<string> ApprovedCampers { get; }
        public IEnumerable<Weekend> Weekends { get; }

        public CalendarEventsModel(EventQueryResult result)
        {
            CalendarEvents = result.Events;
            Weekends = result.Weekends;
            ApprovedCampers = result.ApprovedCampers;
        }
    }
}
