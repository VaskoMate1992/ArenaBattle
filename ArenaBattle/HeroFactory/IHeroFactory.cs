using ArenaBattle.Heroes;

namespace ArenaBattle.HeroFactory
{
    public interface IHeroFactory
    {
        List<Hero> CreateHeroes();
    }
}