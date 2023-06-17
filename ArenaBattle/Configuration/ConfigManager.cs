using Microsoft.Extensions.Configuration;

namespace ArenaBattle.Configuration
{
    public class ConfigManager : IConfigManager
    {
        private readonly IConfiguration _configuration;

        public ConfigManager()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public int HeroCount
        {
            get
            {
                return GetConfigValueByName("HeroCount");
            }
        }

        public int ArcherHealthPoint
        {
            get
            {
                return GetConfigValueByName("InitialHealthPoint:Archer");
            }
        }

        public int RiderHealthPoint
        {
            get
            {
                return GetConfigValueByName("InitialHealthPoint:Rider");
            }
        }

        public int SwordHealthPoint
        {
            get
            {
                return GetConfigValueByName("InitialHealthPoint:Sword");
            }
        }

        #region PrivateHelperMethods

        private int GetConfigValueByName(string configName)
        {
            if (!int.TryParse(_configuration[configName], out int configValue))
            {
                return 0;
            }
            return configValue;
        }

        #endregion
    }
}