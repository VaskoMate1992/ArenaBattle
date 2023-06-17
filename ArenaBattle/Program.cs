using ArenaBattle.Heroes;
using ArenaBattle.HeroFactory;
using ArenaBattle.ServiceConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace ArenaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/arenabattle.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

                Log.Information("Battle has started!");

                IBattleField battleField = serviceProvider.GetRequiredService<IBattleField>();
                IHeroFactory heroesFactory = serviceProvider.GetRequiredService<IHeroFactory>();
                Hero victoriousHero = battleField.Fight(heroesFactory.CreateHeroes());

                Log.Information("Victorious hero: \r\n\t\tId:"
                                + victoriousHero.Id +
                                "\r\n\t\tType: "
                                + victoriousHero.Type.ToString() +
                                "\r\n\t\tHP: " + victoriousHero.CurrentHealthPoint);

                Log.Information("Battle has finished!");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            Console.ReadLine();
        }

        #region HelperMethods

        static void ConfigureServices(ServiceCollection serviceCollection)
        {
            var serviceConfigurator = new ServiceConfigurator();
            serviceConfigurator.ConfigureConfigManager(serviceCollection);
            serviceConfigurator.ConfigureBusinessLogic(serviceCollection);
        }

        #endregion
    }
}