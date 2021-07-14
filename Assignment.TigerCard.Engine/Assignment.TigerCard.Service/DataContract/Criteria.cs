using System;

namespace Assignment.TigerCard.Service
{
    public class Criteria
    {
        public DateTime StartTime { get; set; }
        public Zone Source { get; set; }
        public Zone Destination { get; set; }
    }
}
