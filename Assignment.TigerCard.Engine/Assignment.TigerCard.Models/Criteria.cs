using System;

namespace Assignment.TigerCard.Models
{
    public class Criteria
    {
        public DateTime StartTime { get; set; }
        public Zone Source { get; set; }
        public Zone Destination { get; set; }
    }
}
