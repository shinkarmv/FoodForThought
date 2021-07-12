using System.Collections.Generic;

namespace Assignment.TigerCard.Models
{
    public class Zone
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Station> Stations { get; set; } 
    }
}
