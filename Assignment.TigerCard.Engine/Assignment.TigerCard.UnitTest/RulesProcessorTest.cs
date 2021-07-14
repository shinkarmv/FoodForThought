using Assignment.TigerCard.Contracts;
using Assignment.TigerCard.Models;
using Assignment.TigerCard.Rules;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Assignment.TigerCard.UnitTest
{
    public class RulesProcessorTest
    {
        [Fact]
        public void Cap_GetCap_CapShouldApplied()
        {
            //Arrange
            var configurationProvider = new Mock<IConfigurationProvider>();
            configurationProvider.Setup(x =>
                        x.GetSettingAsObject<List<CapLimits>>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(ConfigurationDataProvider.GetCapLimits());

            List<JourneyDetails> journeyDetails = TestDataProvider.GetJourneyDetailsForApplicableCap();

            //Act
            var ruleProcessor = new RulesProcessor(configurationProvider.Object);
            bool cap = ruleProcessor.Cap(journeyDetails);

            //Assert
            Assert.True(cap);
        }

        [Fact]
        public void Cap_GetCap_CapShouldNotBeApplied()
        {
            //Arrange
            var configurationProvider = new Mock<IConfigurationProvider>();
            configurationProvider.Setup(x =>
                        x.GetSettingAsObject<List<CapLimits>>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(ConfigurationDataProvider.GetCapLimits());

            List<JourneyDetails> journeyDetails = TestDataProvider.GetJourneyDetailsForNoCap();

            //Act
            var ruleProcessor = new RulesProcessor(configurationProvider.Object);
            bool cap = ruleProcessor.Cap(journeyDetails);

            //Assert
            Assert.False(cap);
        }

        [Fact]
        public void Peak_CalculatePeak_PeakFareShouldReturn()
        {
            //Arrange
            var configurationProvider = new Mock<IConfigurationProvider>();
            configurationProvider.Setup(x =>
                        x.GetSettingAsObject<List<TripFare>>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(ConfigurationDataProvider.GetTripFares());

            configurationProvider.Setup(x =>
                        x.GetSettingAsObject<List<PeakHours>>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(ConfigurationDataProvider.GetPeakHours());

            //Act
            var ruleProcessor = new RulesProcessor(configurationProvider.Object);
            var fare = ruleProcessor.Peak(Convert.ToDateTime("10-18-2021 10:00"),
                                            TestDataProvider.ToSourceModel(), 
                                            TestDataProvider.ToDestinationModel());

            //Assert
            Assert.True(fare.Amount == 30);
        }

        [Fact]
        public void Peak_CalculatePeak_PeakFareShouldNotReturn()
        {
            //Arrange
            var configurationProvider = new Mock<IConfigurationProvider>();
            configurationProvider.Setup(x =>
                        x.GetSettingAsObject<List<TripFare>>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(ConfigurationDataProvider.GetTripFares());

            configurationProvider.Setup(x =>
                        x.GetSettingAsObject<List<PeakHours>>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(ConfigurationDataProvider.GetPeakHours());

            //Act
            var ruleProcessor = new RulesProcessor(configurationProvider.Object);
            var fare = ruleProcessor.Peak(Convert.ToDateTime("10-18-2021 14:00"),
                                            TestDataProvider.ToSourceModel(),
                                            TestDataProvider.ToDestinationModel());

            //Assert
            Assert.True(fare.Amount == 25);
        }
    }
}
