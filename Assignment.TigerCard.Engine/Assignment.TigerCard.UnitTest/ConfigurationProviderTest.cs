using Assignment.TigerCard.Rules;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using Xunit;
namespace Assignment.TigerCard.UnitTest
{
    public class ConfigurationProviderTest
    {
        [Fact]
        public void GetSettings_RetrieveSettings_SettingShouldbeReturned()
        {
            //Arrange
            var configurationSection = new Mock<IConfigurationSection>();
            configurationSection.Setup(x => x.Value).Returns("card-wise");
            var configuration = new Mock<IConfiguration>();

            configuration.Setup(x => x.GetSection($"{"default"}:{"storage_path"}"))
                .Returns(configurationSection.Object);

            //Act
            var configurationProvider = new Configuration.ConfigurationProvider(configuration.Object);
            var settings = configurationProvider.GetSetting("default", "storage_path");

            //Assert
            Assert.NotNull(settings);
            Assert.True(settings == "card-wise");
        }

        [Fact]
        public void GetSettings_RetrieveSettings_SettingCollectionObjectShouldbeReturned()
        {
            //Arrange
            var capsSectionMock = new Mock<IConfigurationSection>();
            capsSectionMock.Setup(s => s.Value)
                .Returns("{\"boardingZone\": \"1\",\"destinationZone\": \"1\",\"daily\": 100,\"weekly\": 500}");
            capsSectionMock.Setup(x => x.Key).Returns("caps");

            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x.GetSection($"{"default"}:{"caps"}"))
                .Returns(capsSectionMock.Object);

            //Act
            var configurationProvider = new Configuration.ConfigurationProvider(configuration.Object);
            CapLimits capLimits = configurationProvider.GetSettingAsObject<CapLimits>("default", "caps");

            //Assert
            Assert.NotNull(capLimits);
            Assert.True(capLimits.BoardingZone == "1");
        }

        [Fact]
        public void GetSettings_RetrieveSettings_SettingObjectShouldbeReturned()
        {
            //Arrange
            var capsSectionMock = new Mock<IConfigurationSection>();
            capsSectionMock.Setup(s => s.Value)
                .Returns("[{\"boardingZone\": \"1\",\"destinationZone\": \"1\",\"daily\": 100,\"weekly\": 500},{\"boardingZone\": \"1\",\"destinationZone\": \"1\",\"daily\": 100,\"weekly\": 500}]");
            capsSectionMock.Setup(x => x.Key).Returns("caps");

            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x.GetSection($"{"default"}:{"caps"}"))
                .Returns(capsSectionMock.Object);

            //Act
            var configurationProvider = new Configuration.ConfigurationProvider(configuration.Object);
            List<CapLimits> capLimits = configurationProvider.GetSettingAsObject<List<CapLimits>>("default", "caps");

            //Assert
            Assert.NotNull(capLimits);
            Assert.True(capLimits[0].BoardingZone == "1");
        }
    }
}
