using ArenaBattle.Heroes;

namespace ArenaBattle
{
    public interface IBattleField
    {
        Hero Fight(List<Hero> heroes);
    }
}