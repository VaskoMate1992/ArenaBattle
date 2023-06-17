using ArenaBattle.Configuration;
using ArenaBattle.Helpers;
using ArenaBattle.Heroes;

namespace ArenaBattle.HeroFactory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IConfigManager _configManager;

        private readonly IRollHelper _rollHelper;

        public HeroFactory(IConfigManager configManager, IRollHelper rollHelper)
        {
            _configManager = configManager ?? throw new ArgumentNullException(nameof(configManager));
            _rollHelper = rollHelper ?? throw new ArgumentNullException(nameof(rollHelper));
        }

        public List<Hero> CreateHeroes()
        {
            var heros = new List<Hero>();
            var rnd = new Random();
            int heroTypeIndex;
            for (var i = 0; i < _configManager.HeroCount; i++)
            {
                heroTypeIndex = rnd.Next(1, 4);
                switch (heroTypeIndex)
                {
                    case 1:
                        heros.Add(new Archer(Guid.NewGuid(), _configManager.ArcherHealthPoint));
                        break;
                    case 2:
                        heros.Add(new Rider(Guid.NewGuid(), _configManager.RiderHealthPoint, _rollHelper));
                        break;
                    case 3:
                        heros.Add(new Sword(Guid.NewGuid(), _configManager.SwordHealthPoint));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("There is no such hero!");
                }
            }

            return heros;
        }
    }
}