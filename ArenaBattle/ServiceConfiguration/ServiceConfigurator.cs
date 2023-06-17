using ArenaBattle.Configuration;
using ArenaBattle.Helpers;
using ArenaBattle.HeroFactory;
using Microsoft.Extensions.DependencyInjection;

namespace ArenaBattle.ServiceConfiguration
{
    class ServiceConfigurator
    {
        public void ConfigureConfigManager(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IConfigManager, ConfigManager>();
        }

        public void ConfigureBusinessLogic(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHeroFactory, HeroFactory.HeroFactory>();
            serviceCollection.AddTransient<IBattleField, BattleField>();
            serviceCollection.AddTransient<IRollHelper, RollHelper>();
        }
    }
}