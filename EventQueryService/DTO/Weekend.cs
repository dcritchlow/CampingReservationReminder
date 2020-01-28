using System;

namespace EventQueryService.DTO
{
    public class Weekend
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public override string ToString() => $"{Start.ToString("MM/dd")}-{End.ToString("MM/dd")}";
    }
}