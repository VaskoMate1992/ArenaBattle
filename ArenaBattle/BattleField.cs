using ArenaBattle.Heroes;
using Serilog;

namespace ArenaBattle
{
    public class BattleField : IBattleField
    {
        Hero IBattleField.Fight(List<Hero> heroes)
        {
            Hero offensiveHero;
            Hero defensiveHero;
            int battleRound = 1;
            do
            {
                offensiveHero = GetOffensiveHero(heroes);
                defensiveHero = GetDefensiveHero(heroes, offensiveHero);
                offensiveHero.Attack(defensiveHero);
                heroes.Where(x => x.Id != offensiveHero.Id && x.Id != defensiveHero.Id)
                      .ToList()
                      .ForEach(x => x.Rest());
                DiedHeroRemove(offensiveHero, defensiveHero, heroes);
                Log.Information("Battle round: " + battleRound +
                                "\r\nOffensive hero:\r\n" + offensiveHero.ToString() +
                                "\r\n" + "Defensive hero:\r\n" + defensiveHero.ToString());
                battleRound++;
            } while (heroes.Count != 1);

            return heroes[0];
        }

        #region PrivateHelperMethods

        private Hero GetOffensiveHero(List<Hero> heroes)
        {
            return heroes[Random.Shared.Next(heroes.Count)];
        }

        private Hero GetDefensiveHero(List<Hero> heroes, Hero offensiveHero)
        {
            Hero defensiveHero;

            do
            {
                defensiveHero = heroes[Random.Shared.Next(heroes.Count)];
            } while (defensiveHero.Id == offensiveHero.Id);

            return defensiveHero;
        }

        private void DiedHeroRemove(Hero offensiveHero, Hero defensiveHero, List<Hero> heroes)
        {
            if (offensiveHero.IsDied())
            {
                heroes.Remove(offensiveHero);
            }
            if (heroes.Count > 1 && defensiveHero.IsDied())
            {
                heroes.Remove(defensiveHero);
            }
        }

        #endregion
    }
}