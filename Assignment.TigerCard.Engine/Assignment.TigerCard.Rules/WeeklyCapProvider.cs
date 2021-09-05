using Assignment.TigerCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment.TigerCard.Rules
{
    public class WeeklyCapProvider : ICapProvider
    {

        public bool IsCapApplicable(List<JourneyDetails> journeyList, CapLimits capLimits)
        {
            var weeklySumOfFare = journeyList.FindAll(x => x.Criteria.Source.Id == capLimits.BoardingZone
                                        && x.Criteria.Destination.Id == capLimits.DestinationZone)
                                        .Sum(x => x.Fare.Amount);

           return capLimits.Weekly <= weeklySumOfFare;
        }
    }
}
