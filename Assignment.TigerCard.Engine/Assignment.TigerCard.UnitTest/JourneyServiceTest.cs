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
            var journeyDateTime = Convert.ToDateTime("10-18-2021 14:00");
            var journeyRequest = TestDataProvider.GetJourneyRequest(journeyDateTime);
            var journeyComponent = new Mock<IJourneyComponent>();
            journeyComponent.Setup(x => x.Commute(It.IsAny<Models.Criteria>(), It.IsAny<Models.Card>()))
                .Returns(new Models.Fare { Amount = 20, Description = "Non Peak Fare" });

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
            var journeyDateTime = Convert.ToDateTime("10-18-2021 10:00");
            var journeyRequest = TestDataProvider.GetJourneyRequest(journeyDateTime);
            var journeyComponent = new Mock<IJourneyComponent>();
            journeyComponent.Setup(x => x.Commute(It.IsAny<Models.Criteria>(), It.IsAny<Models.Card>()))
                .Returns(new Models.Fare { Amount = 25, Description = "Non Peak Fare" });

            //Act
            var journeyService = new JourneyService(journeyComponent.Object);
            var journeyResponse = journeyService.Journey(journeyRequest);

            //Assert
            Assert.NotNull(journeyResponse);
            Assert.True(journeyResponse.Fare.Amount == 25);
        }
    }
}
