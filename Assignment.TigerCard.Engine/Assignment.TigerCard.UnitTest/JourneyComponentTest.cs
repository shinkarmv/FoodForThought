using Assignment.TigerCard.Contracts;
using Assignment.TigerCard.Engine;
using Assignment.TigerCard.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Assignment.TigerCard.UnitTest
{
    public class JourneyComponentTest
    {
        [Fact]
        public void Commute_CalculateFare_NonPeakHoursFareShouldReturn()
        {
            // Arrange
            var journeyDateTime = Convert.ToDateTime("10-18-2021 14:00");
            var criteria = TestDataProvider.GetCriteria(journeyDateTime);
            var card = TestDataProvider.GetCardModel();

            var ruleProcessor = new Mock<IRuleProcessor>();
            ruleProcessor.Setup(x => x.Cap(It.IsAny<List<JourneyDetails>>())).Returns(It.IsAny<bool>());
            ruleProcessor.Setup(x => x.Peak(It.IsAny<DateTime>(), It.IsAny<Zone>(), It.IsAny<Zone>()))
                .Returns(new Models.Fare { Amount = 20, Description = "Non Peak Fare" });

            var journeyStoreProvider = new Mock<IJouneryStoreProvider>();
            journeyStoreProvider.Setup(x => x.GetListOfJourneyDetails(It.IsAny<string>(), It.IsAny<DateTime>()));
            journeyStoreProvider.Setup(x => x.SaveJourneyDetails(It.IsAny<Criteria>(), It.IsAny<Fare>(), It.IsAny<Card>()));

            //Act
            var journeyComponent = new JourneyComponent(ruleProcessor.Object, journeyStoreProvider.Object);
            var fare = journeyComponent.Commute(criteria, card);

            //Assert
            Assert.NotNull(fare);
            Assert.True(fare.Amount == 20);
        }

        [Fact]
        public void Commute_CalculateFare_PeakHoursFareShouldReturn()
        {
            // Arrange
            var journeyDateTime = Convert.ToDateTime("10-18-2021 10:00");
            var criteria = TestDataProvider.GetCriteria(journeyDateTime);
            var card = TestDataProvider.GetCardModel();

            var ruleProcessor = new Mock<IRuleProcessor>();
            ruleProcessor.Setup(x => x.Cap(It.IsAny<List<JourneyDetails>>())).Returns(It.IsAny<bool>());
            ruleProcessor.Setup(x => x.Peak(It.IsAny<DateTime>(), It.IsAny<Zone>(), It.IsAny<Zone>()))
                .Returns(new Models.Fare { Amount = 25, Description = "Peak Fare" });

            var journeyStoreProvider = new Mock<IJouneryStoreProvider>();
            journeyStoreProvider.Setup(x => x.GetListOfJourneyDetails(It.IsAny<string>(), It.IsAny<DateTime>()));
            journeyStoreProvider.Setup(x => x.SaveJourneyDetails(It.IsAny<Criteria>(), It.IsAny<Fare>(), It.IsAny<Card>()));

            //Act
            var journeyComponent = new JourneyComponent(ruleProcessor.Object, journeyStoreProvider.Object);
            var fare = journeyComponent.Commute(criteria, card);

            //Assert
            Assert.NotNull(fare);
            Assert.True(fare.Amount == 25);
        }
    }
}
