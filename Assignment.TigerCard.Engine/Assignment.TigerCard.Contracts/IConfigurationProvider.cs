namespace Assignment.TigerCard.Contracts
{
    public interface IConfigurationProvider
    {
        string GetSetting(string section, string key);

        T GetSettingAsObject<T>(string section, string key);
    }
}
