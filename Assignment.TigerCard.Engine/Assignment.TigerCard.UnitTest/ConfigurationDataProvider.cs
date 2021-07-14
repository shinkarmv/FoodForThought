using System;
using System.Collections.Generic;
using Assignment.TigerCard.Rules;

namespace Assignment.TigerCard.UnitTest
{
    internal static class ConfigurationDataProvider
    {

        internal static List<CapLimits> GetCapLimits()
        {
            return new List<CapLimits>
                {
                    new CapLimits
                    {
                        BoardingZone = "1",
                        DestinationZone = "1",
                        Daily = 100,
                        Weekly = 500
                    },
                    new CapLimits
                    {
                        BoardingZone = "1",
                        DestinationZone = "2",
                        Daily = 120,
                        Weekly = 600
                    },
                    new CapLimits
                    {
                        BoardingZone = "2",
                        DestinationZone = "1",
                        Daily = 120,
                        Weekly = 600
                    },
                    new CapLimits
                    {
                        BoardingZone = "2",
                        DestinationZone = "1",
                        Daily = 80,
                        Weekly = 400
                    }
                };
        }

        internal static List<TripFare> GetTripFares()
        {
            return new List<TripFare>
            {
                new TripFare
                {
                    BoardingZone = "1",
                    DestinationZone = "1",
                    FareAmount = 25,
                    PeakPercent = 20
                },
                new TripFare
                {
                    BoardingZone = "1",
                    DestinationZone = "2",
                    FareAmount = 30,
                    PeakPercent = 16.67m
                },
                new TripFare
                {
                    BoardingZone = "2",
                    DestinationZone = "1",
                    FareAmount = 30,
                    PeakPercent = 16.67m
                },
                new TripFare
                {
                    BoardingZone = "2",
                    DestinationZone = "1",
                    FareAmount = 20,
                    PeakPercent = 25
                }
            };
        }

        internal static List<PeakHours> GetPeakHours()
        {
            return new List<PeakHours>
            { 
                SetPeakHours("Monday"),
                SetPeakHours("Tuesday"),
                SetPeakHours("Wednesday"),
                SetPeakHours("Thursday"),
                SetPeakHours("Friday"),
                SetPeakHours("Saturday", new string[]{"09:00", "11:00" },  new string[]{"18:00", "22:00" }),
                SetPeakHours("Sunday", new string[]{"09:00", "11:00" },  new string[]{"18:00", "22:00" }),
            };
        }

        private static PeakHours SetPeakHours(string dayOfWeek)
        {
            return new PeakHours
            {
                DayOfWeek = dayOfWeek,
                Windows = new List<Window>
                    {
                        new Window
                        {
                            Start = Convert.ToDateTime("01-01-1900 07:00"),
                            End = Convert.ToDateTime("01-01-1900 10:30")
                        },
                        new Window
                        {
                            Start = Convert.ToDateTime("01-01-1900 17:00"),
                            End = Convert.ToDateTime("01-01-1900 20:00")
                        }
                    }
            };
        }
        private static PeakHours SetPeakHours(string dayOfWeek, string[] morningWindow, string[] eveningWindow)
        {
            return new PeakHours
            {
                DayOfWeek = dayOfWeek,
                Windows = new List<Window>
                    {
                        new Window
                        {
                            Start = Convert.ToDateTime("01-01-1900 " + morningWindow[0]),
                            End = Convert.ToDateTime("01-01-1900 " + morningWindow[1]),
                        },
                        new Window
                        {
                            Start = Convert.ToDateTime("01-01-1900 " + eveningWindow[0]),
                            End = Convert.ToDateTime("01-01-1900 " + eveningWindow[1]),
                        }
                    }
            };
        }
    }
}
