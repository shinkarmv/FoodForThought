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

        public RulesProcessor(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }
        public bool Cap(List<JourneyDetails> journeyList)
        {
            var capLimits = _configurationProvider.GetSettingAsObject<CapLimits>("default", "caps");
            var sumOfFare = journeyList.Sum(x => x.Fare.Amount);
            return capLimits.Weekly >= sumOfFare || capLimits.Daily >= sumOfFare;
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
            var peakHours = _configurationProvider.GetSettingAsObject<PeakHours>("default", "peak_hours");
            if(peakHours.Day == journeyDateTime.Day 
                && peakHours.Window.Start >= journeyDateTime 
                && peakHours.Window.End <= journeyDateTime)
            {
                return true;
            }
            return false;
        }
    }
}
