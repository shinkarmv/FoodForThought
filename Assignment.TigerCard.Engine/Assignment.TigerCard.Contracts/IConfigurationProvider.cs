using System.Collections.Generic;

namespace Assignment.TigerCard.Contracts
{
    public interface IConfigurationProvider
    {
        string GetGlobalSetting(string section, string key);

        T GetGlobalSettingAsDisctionary<T>(string section, string key);
    }
}
