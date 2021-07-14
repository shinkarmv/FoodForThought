using Assignment.TigerCard.Contracts;
using Assignment.TigerCard.Service;
using Moq;
using System;
using Xunit;

namespace Assignment.TigerCard.UnitTest
{
    public class JourneyServiceTest
    {
        [Fact]
        public void Journey_CalculateFare_NonPeakHoursFareShouldReturn()
        {
            // Arrange
            var journeyDateTime = Convert.ToDateTime("18/10/2021:14:00:00");
            var journeyRequest = GetJourneyRequest(journeyDateTime);
            var journeyComponent = new Mock<IJourneyComponent>();
            journeyComponent.Setup(x => x.Commute(It.IsAny<Models.Criteria>(), It.IsAny<Models.Card>()))
                .Returns(It.IsAny<Models.Fare>());

            //Act
            var journeyService = new JourneyService(journeyComponent.Object);
            var journeyResponse = journeyService.Journey(journeyRequest);

            //Assert
            Assert.NotNull(journeyResponse);
            Assert.True(journeyResponse.Fare.Amount == 20);
        }

        [Fact]
        public void Journey_CalculateFare_PeakHoursFareShouldReturn()
        {
            // Arrange
            var journeyDateTime = Convert.ToDateTime("18/10/2021:10:00:00");
            var journeyRequest = GetJourneyRequest(journeyDateTime);
            var journeyComponent = new Mock<IJourneyComponent>();
            journeyComponent.Setup(x => x.Commute(It.IsAny<Models.Criteria>(), It.IsAny<Models.Card>()))
                .Returns(It.IsAny<Models.Fare>());

            //Act
            var journeyService = new JourneyService(journeyComponent.Object);
            var journeyResponse = journeyService.Journey(journeyRequest);

            //Assert
            Assert.NotNull(journeyResponse);
            Assert.True(journeyResponse.Fare.Amount == 25);
        }

        private JourneyRequest GetJourneyRequest(DateTime journeyDateTime)
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
    }
}
