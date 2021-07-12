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
        public JourneyDetails GetJourneyDetails(string journeyId, string tigerCardNumber)
        {
            var directoryPath = GetAssemblyDirectory() + _configurationProvider.GetGlobalSetting("details", "card-wise");
            string fullPath = directoryPath + tigerCardNumber + "/" + journeyId;
            var json = GetResourceTextFile(fullPath);

            var response = JsonConvert.DeserializeObject<JourneyDetails>(json,
                   GetJsonSerializerSettings());

            return response;
        }

        public List<JourneyDetails> GetListOfJourneyDetails(string tigerCardNumber)
        {
            List<JourneyDetails> journeyDetailList = new List<JourneyDetails>();
            var directoryPath = GetAssemblyDirectory() + _configurationProvider.GetGlobalSetting("details", "card-wise");
            string fullPath = directoryPath + tigerCardNumber;

            foreach (var item in Directory.GetFiles(fullPath))
            {
                fullPath = fullPath + item;
                var json = GetResourceTextFile(fullPath);

                var response = JsonConvert.DeserializeObject<JourneyDetails>(json,
                       GetJsonSerializerSettings());

                journeyDetailList.Add(response);
            }


            return journeyDetailList;
        }

        public void SaveJourneyDetails(JourneyDetails journeyDetails)
        {
            var directoryPath = GetAssemblyDirectory() + _configurationProvider.GetGlobalSetting("details", "card-wise");
            if (!Directory.Exists(directoryPath))
            {
                directoryPath = Directory.CreateDirectory(directoryPath).FullName;
            }
            var serializeJourneyDetails = SerializeJourneyDetailsToJsonString(journeyDetails);
            string fileName = journeyDetails.Card.Number + "/" + journeyDetails.JourneyId;
            string fullPath = directoryPath + fileName;
            File.WriteAllText(fullPath, serializeJourneyDetails);
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
