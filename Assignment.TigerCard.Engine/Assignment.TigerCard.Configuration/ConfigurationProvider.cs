﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using IConfigurationProvider = Assignment.TigerCard.Contracts.IConfigurationProvider;

namespace Assignment.TigerCard.Configuration
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        public ConfigurationProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetSetting(string section, string key)
        {
            var value = _configuration.GetSection($"{section}:{key}").Value;
            return value;
        }

        public T GetSettingAsObject<T>(string section, string key)
        {
            var value = _configuration.GetSection($"{section}:{key}").Value;
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
