using Assignment.TigerCard.Contracts;
using Assignment.TigerCard.JourneyStore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Assignment.TigerCard.UnitTest
{
    public class JourneyStoreProviderTests
    {
        [Fact]
        public void SaveJourneyDetails_SaveData_Saved()
        {
            //Arrange
            var configurationProvider = new Mock<IConfigurationProvider>();
            configurationProvider.Setup(x =>
                        x.GetSetting(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("card-wise-journey-store");

            //Act
            var fileBasedStore = new FileBasedStore(configurationProvider.Object);
            var saved = fileBasedStore.SaveJourneyDetails(TestDataProvider.GetCriteria(Convert.ToDateTime("10-18-2021 14:00")),
                new Models.Fare { Amount = 25, Description = "Peak Hours Fare" },
                TestDataProvider.GetCardModel());

            //Assert
            Assert.True(saved);
        }

        [Fact]
        public void GetListOfJourneyDetails_RetrieveJourney_All()
        {
            //Arrange
            var configurationProvider = new Mock<IConfigurationProvider>();
            configurationProvider.Setup(x =>
                        x.GetSetting(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("card-wise-journey-store");

            //Act
            var fileBasedStore = new FileBasedStore(configurationProvider.Object);
            var journeyList = fileBasedStore.GetListOfJourneyDetails("123456789", Convert.ToDateTime("10-18-2021 14:00"));

            //Assert
            Assert.NotNull(journeyList);
            Assert.Equal("123456789", journeyList[0].Card.Number);
        }

    }
}
