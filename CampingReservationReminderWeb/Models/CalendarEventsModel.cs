using System.Collections.Generic;
using EventQueryService.DTO;

namespace CampingReservationReminderWeb.Models
{
    public class CalendarEventsModel
    {
        public IEnumerable<CalendarEvent> CalendarEvents { get; }
        public IEnumerable<Camper> Campers { get; }
        public List<string> ApprovedCampers { get; } = EventQueryService.DTO.ApprovedCampers.List;

        public CalendarEventsModel(IEnumerable<CalendarEvent> events)
        {
            CalendarEvents = events;
        }
    }
}
