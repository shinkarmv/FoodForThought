using Assignment.TigerCard.Contracts;
using Assignment.TigerCard.Models;
using System;
using System.Collections.Generic;

namespace Assignment.TigerCard.Rules
{
    public class RulesProcessor : IRuleProcessor
    {
        public bool Cap(List<JourneyDetails> journeyList)
        {
            return true;
        }

        public Fare Peak(DateTime journeyDateTime, Zone boardingZone, Zone destinationZone)
        {
            throw new NotImplementedException();
        }
    }
}
