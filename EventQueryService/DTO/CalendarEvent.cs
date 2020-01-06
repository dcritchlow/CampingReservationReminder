﻿using System;
namespace EventQueryService.DTO
{
    public class CalendarEvent
    {
        public string Summary { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string CampType { get; set; }
        public string Website { get; set; }

        public override string ToString() => $"{Summary} {Start} - {End} ({CampType}) {Website}";
    }
}
