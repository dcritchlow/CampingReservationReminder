using System;
using System.Collections.Generic;
using System.Linq;
using EventQueryService.DTO;

namespace EventQueryService.AvailableWeekends
{
    public class FridayToSundayWeekend : IAvailableWeekend
    {
        public FridayToSundayWeekend()
        {
        }

        private IEnumerable<DateTime> GetDaysBetween(DateTime start, DateTime end)
        {
            for (DateTime i = start; i < end; i = i.AddDays(1))
            {
                yield return i;
            }
        }

        public IEnumerable<Weekend> Weekends()
        {
            var weekends = GetDaysBetween(new DateTime(DateTime.Now.Year, 4, 1), new DateTime(DateTime.Now.Year, 11, 1))
                .Where(d => d.DayOfWeek == DayOfWeek.Friday);
            var result = weekends.Select((start) => BuildWeekend(start));
            
            return result;
        }

        private Weekend BuildWeekend(DateTime start)
        {
            return new Weekend
            {
                Start = start,
                End = start.AddDays(2)
            };
        }
    }
}