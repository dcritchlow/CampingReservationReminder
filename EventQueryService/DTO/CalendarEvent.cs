using System;
using System.Collections.Generic;

namespace EventQueryService.DTO
{
    public class CalendarEvent
    {
        public string Summary { get; set; }
        public string Start { get; set; }
        public DateTime StartDateTime { get; set; }
        public string End { get; set; }
        public DateTime EndDateTime { get; set; }
        public string CampType { get; set; }
        public string Website { get; set; }
        public List<Camper> Campers { get; set; }

        public override string ToString() => $"{Summary} {Start} - {End} ({CampType}) {Website}";
    }
}
