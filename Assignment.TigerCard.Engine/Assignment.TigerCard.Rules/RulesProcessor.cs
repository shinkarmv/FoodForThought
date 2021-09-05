using Assignment.TigerCard.Contracts;
using Assignment.TigerCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.TigerCard.Rules
{
    public class RulesProcessor : IRuleProcessor
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly List<ICapProvider> _capProvider;

        public RulesProcessor(IConfigurationProvider configurationProvider, List<ICapProvider> capProvider)
        {
            _configurationProvider = configurationProvider;
            _capProvider = capProvider;
        }
        public bool Cap(List<JourneyDetails> journeyList)
        {
            var capLimits = _configurationProvider.GetSettingAsObject<List<CapLimits>>("default", "caps");

            return capLimits.Any(capLimit => 
            {
               return _capProvider.Any(x => x.IsCapApplicable(journeyList, capLimit));
            });
        }

        public Fare Peak(DateTime journeyDateTime, Zone boardingZone, Zone destinationZone)
        {
            Fare fare = new Fare
            {
                Amount = 0.0m,
                Description = "Expected Fare of Journey"
            };

            var belongToPeakHours = CheckIfJourneyTimeBelongsToPeakHours(journeyDateTime);
            var tripFareList = _configurationProvider.GetSettingAsObject<List<TripFare>>("default", "trip_fare");
            
            foreach (var item in tripFareList)
            {
                if(item.BoardingZone == boardingZone.Id && item.DestinationZone == destinationZone.Id)
                {
                    if (belongToPeakHours)
                    {
                        decimal peakHourCharge = item.FareAmount * item.PeakPercent / 100;
                        fare.Amount = item.FareAmount + peakHourCharge;
                        return fare;
                    }
                    fare.Amount = item.FareAmount;
                    return fare;
                }
            }
            
            return fare;
        }

        private bool CheckIfJourneyTimeBelongsToPeakHours(DateTime journeyDateTime)
        {
            var peakHours = _configurationProvider.GetSettingAsObject<List<PeakHours>>("default", "peak_hours");
            foreach (var item in peakHours)
            {
                if (item.DayOfWeek == journeyDateTime.DayOfWeek.ToString())
                {
                    foreach (var window in item.Windows)
                    {
                        if (Convert.ToInt32(window.Start.ToString("hh")) <= Convert.ToInt32(journeyDateTime.ToString("hh"))
                            && Convert.ToInt32(window.End.ToString("hh")) >= Convert.ToInt32(journeyDateTime.ToString("hh")))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
