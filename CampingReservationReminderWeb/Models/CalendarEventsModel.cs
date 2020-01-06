﻿using System;
using System.Collections.Generic;
using EventQueryService.DTO;

namespace CampingReservationReminderWeb.Models
{
    public class CalendarEventsModel
    {
        public IEnumerable<CalendarEvent> CalendarEvents { get; }

        public CalendarEventsModel(IEnumerable<CalendarEvent> events)
        {
            CalendarEvents = events;
        }
    }
}