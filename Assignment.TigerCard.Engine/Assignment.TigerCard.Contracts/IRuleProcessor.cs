using Assignment.TigerCard.Models;
using System;
using System.Collections.Generic;

namespace Assignment.TigerCard.Contracts
{
    public interface IRuleProcessor
    {
        bool Cap(List<JourneyDetails> journeyList);

        Fare Peak(DateTime journeyDateTime, Zone boardingZone, Zone destinationZone);

    }
}
