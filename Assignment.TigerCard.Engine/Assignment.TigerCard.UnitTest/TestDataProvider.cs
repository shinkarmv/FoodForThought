
using Assignment.TigerCard.Service;
using System;
using System.Collections.Generic;

namespace Assignment.TigerCard.UnitTest
{
    internal static class TestDataProvider
    {
        internal static JourneyRequest GetJourneyRequest(DateTime journeyDateTime)
        {
            return new JourneyRequest
            {
                Criteria = ToCriteria(journeyDateTime),
                TigerCard = new Service.TigerCard
                {
                    Number = "123456789",
                    Name = "John Doe",
                    Balance = new Balance
                    {
                        Amount = 100000,
                        Currency = "USD"
                    }
                }
            };
        }
        private static Criteria ToCriteria(DateTime journeyDateTime)
        {
            return new Criteria
            {
                Source = ToSource(),
                StartTime = journeyDateTime,
                Destination = ToDestination(),
            };
        }
        private static Zone ToDestination()
        {
            return new Zone
            {
                Id = "1",
                Name = "Bund Garden",
                Stations = new System.Collections.Generic.List<Station>
                        {
                            new Station
                            {
                                Code = "100",
                                Name = "Shivaji Nagar"
                            }
                        }
            };
        }
        private static Zone ToSource()
        {
            return new Zone
            {
                Id = "1",
                Name = "Bund Garden",
                Stations = new System.Collections.Generic.List<Station>
                        {
                            new Station
                            {
                                Code = "011",
                                Name = "Pune Station"
                            }
                        }
            };
        }
        internal static Models.Card GetCardModel()
        {
            return new Models.Card
            {
                Number = "123456789",
                Name = "John Doe",
                Balance = new Models.Balance
                {
                    Amount = 100000,
                    Currency = "USD"
                }
            };
        }
        internal static Models.Criteria GetCriteria(DateTime journeyDateTime)
        {
            return new Models.Criteria
            {
                Source = ToSourceModel(),
                Destination = ToDestinationModel(),
                StartTime = journeyDateTime,
            };
        }
        internal static Models.Zone ToSourceModel()
        {
            return new Models.Zone
            {
                Id = "1",
                Name = "Bund Garden",
                Stations = new System.Collections.Generic.List<Models.Station>
                        {
                            new Models.Station
                            {
                                Code = "011",
                                Name = "Pune Station"
                            }
                        }
            };
        }
        internal static Models.Zone ToDestinationModel()
        {
            return new Models.Zone
            {
                Id = "1",
                Name = "Bund Garden",
                Stations = new System.Collections.Generic.List<Models.Station>
                        {
                            new Models.Station
                            {
                                Code = "100",
                                Name = "Shivaji Nagar"
                            }
                        }
            };
        }
        internal static List<Models.JourneyDetails> GetJourneyDetailsForApplicableCap()
        {
            return new List<Models.JourneyDetails>
            {
                PeakHourJourney(Convert.ToDateTime("10-18-2021 10:00")),
                //NonPeakHourJourney(Convert.ToDateTime("10-18-2021 14:00")),
                //NonPeakHourJourney(Convert.ToDateTime("10-19-2021 14:00")),
                //PeakHourJourney(Convert.ToDateTime("10-18-2021 07:00")),
                //PeakHourJourney(Convert.ToDateTime("10-18-2021 09:00")),
                //PeakHourJourney(Convert.ToDateTime("10-19-2021 07:00")),
                //PeakHourJourney(Convert.ToDateTime("10-19-2021 09:00")),
                //PeakHourJourney(Convert.ToDateTime("10-20-2021 07:00")),
                //PeakHourJourney(Convert.ToDateTime("10-20-2021 09:00")),
                //PeakHourJourney(Convert.ToDateTime("10-18-2021 18:00")),
                //PeakHourJourney(Convert.ToDateTime("10-18-2021 19:00")),
                //PeakHourJourney(Convert.ToDateTime("10-20-2021 18:00")),
                //PeakHourJourney(Convert.ToDateTime("10-20-2021 19:00")),
                //PeakHourJourney(Convert.ToDateTime("10-19-2021 18:00")),
                //PeakHourJourney(Convert.ToDateTime("10-19-2021 19:00")),
                //NonPeakHourJourney(Convert.ToDateTime("10-20-2021 14:00")),
                //NonPeakHourJourney(Convert.ToDateTime("10-21-2021 14:00")),
                //NonPeakHourJourney(Convert.ToDateTime("10-18-2021 16:00")),
                //NonPeakHourJourney(Convert.ToDateTime("10-19-2021 17:00")),
            };
        }
        private static Models.JourneyDetails NonPeakHourJourney(DateTime journeyDateTime)
        {
            return new Models.JourneyDetails
            {
                Criteria = new Models.Criteria
                {
                    Source = ToSourceModel(),
                    Destination = ToDestinationModel(),
                    StartTime = journeyDateTime
                },
                Card = GetCardModel(),
                Fare = new Models.Fare
                {
                    Amount = 25,
                    Description = "Non Peak Hours"
                }
            };
        }
        private static Models.JourneyDetails PeakHourJourney(DateTime journeyDateTime)
        {
            return new Models.JourneyDetails
            {
                Criteria = new Models.Criteria
                {
                    Source = ToSourceModel(),
                    Destination = ToDestinationModel(),
                    StartTime = journeyDateTime
                },
                Card = GetCardModel(),
                Fare = new Models.Fare
                {
                    Amount = 30,
                    Description = "Peak Hours"
                }
            };
        }
        internal static List<Models.JourneyDetails> GetJourneyDetailsForNoCap()
        {
            return new List<Models.JourneyDetails>
            {
                PeakHourJourney(Convert.ToDateTime("10-18-2021 10:00")),
                NonPeakHourJourney(Convert.ToDateTime("10-18-2021 14:00")),
                NonPeakHourJourney(Convert.ToDateTime("10-19-2021 14:00")),
            };
        }
    }
}
