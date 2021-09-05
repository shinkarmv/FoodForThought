using System;
using System.Collections.Generic;
using System.Text;
using Assignment.TigerCard.Models;

namespace Assignment.TigerCard.Service
{
    public class Zone
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Station> Stations { get; set; }
    }
}
