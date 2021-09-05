using Assignment.TigerCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment.TigerCard.Rules
{
    public class DailyCapProvider : ICapProvider
    {
        public bool IsCapApplicable(List<JourneyDetails> journeyList, CapLimits capLimits)
        {
            var dailySumOfFare = journeyList.FindAll(x => x.Criteria.Source.Id == capLimits.BoardingZone
                                    && x.Criteria.Destination.Id == capLimits.DestinationZone
                                    && x.Criteria.StartTime.ToString("mm/dd/yyyy").Equals(DateTime.Now.ToString("mm/dd/yyyy")))
                                    .Sum(x => x.Fare.Amount);

            return capLimits.Daily <= dailySumOfFare;
        }
    }
}
