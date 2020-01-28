using System.Collections.Generic;
using EventQueryService.DTO;

namespace EventQueryService
{
    public interface IAvailableWeekend
    {
        public IEnumerable<Weekend> Weekends();
    }
}
