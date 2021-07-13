using Assignment.TigerCard.Contracts;
using Assignment.TigerCard.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Assignment.TigerCard.JourneyStore
{
    public class FileBasedStore : IJouneryStoreProvider
    {
        private readonly IConfigurationProvider _configurationProvider;
        public FileBasedStore(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public List<JourneyDetails> GetListOfJourneyDetails(string tigerCardNumber, DateTime journeyDate)
        {
            List<JourneyDetails> journeyDetailList = new List<JourneyDetails>();
            string directoryPath = GetDirectoryPath(tigerCardNumber, journeyDate);

            foreach (var item in Directory.GetFiles(directoryPath))
            {
                directoryPath += item;
                var json = GetResourceTextFile(directoryPath);

                var response = JsonConvert.DeserializeObject<JourneyDetails>(json,
                       GetJsonSerializerSettings());

                journeyDetailList.Add(response);
            }

            return journeyDetailList;
        }

        public void SaveJourneyDetails(Criteria criteria, Fare fare, Card card)
        {
            JourneyDetails journeyDetails = PrepareJourneryDetails(criteria, fare, card);
            string directoryPath = GetDirectoryPath(journeyDetails.Card.Number, journeyDetails.Criteria.StartTime);
            var serializeJourneyDetails = SerializeJourneyDetailsToJsonString(journeyDetails);
            string fileName = journeyDetails.JourneyId;
            string fullPath = directoryPath + fileName;
            File.WriteAllText(fullPath, serializeJourneyDetails);
        }

        private JourneyDetails PrepareJourneryDetails(Criteria criteria, Fare fare, Card card)
        {
            return new JourneyDetails
            {
                Criteria = criteria,
                Fare = fare,
                JourneyId = Guid.NewGuid().ToString(),
                Card = card
            };
        }

        private string GetDirectoryPath(string number, DateTime journeyDate)
        {
            var directoryPath = GetAssemblyDirectory() + _configurationProvider.GetSetting("details", "card-wise");
            if (!Directory.Exists(directoryPath))
            {
                directoryPath = Directory.CreateDirectory(directoryPath).FullName;
            }

            directoryPath = Directory.CreateDirectory(directoryPath + number
                + journeyDate.Month.ToString()
                + GetWeekNumberOfMonth(journeyDate)).FullName;
            return directoryPath;
        }

        private string GetWeekNumberOfMonth(DateTime date)
        {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }
            return ((date - firstMonthMonday).Days / 7 + 1).ToString();
        }

        private string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);            
        }

        private static string SerializeJourneyDetailsToJsonString<T>(T journeyDetails)
        {
            return JsonConvert.SerializeObject(journeyDetails,
                                        new JsonSerializerSettings
                                        {
                                            TypeNameHandling = TypeNameHandling.All
                                        });
        }

        private JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            };
        }

        private string GetResourceTextFile(string filename)
        {
            using (var stream = GetType().Assembly.GetManifestResourceStream(filename))
            {
                return stream != null ? GetStreamString(stream) : string.Empty;
            }
        }

        private string GetStreamString(Stream stream)
        {
            string result;
            using (var sr = new StreamReader(stream))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }
    }
}
