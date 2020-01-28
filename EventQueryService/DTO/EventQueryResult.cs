using System.Collections.Generic;

namespace EventQueryService.DTO
{
    public class EventQueryResult
    {
        public IEnumerable<CalendarEvent> Events { get; set; }
        public IEnumerable<Weekend> Weekends { get; set; }
        public List<string> ApprovedCampers { get; set; }
    }
}