using ArenaBattle.Helpers;
using ArenaBattle.Heroes.Enums;

namespace ArenaBattle.Heroes
{
    public class Rider : Hero
    {
        private readonly IRollHelper _rollHelper;

        public Rider(Guid id, int healthPoint, IRollHelper rollHelper) : base(id, healthPoint, HeroTypes.Rider)
        {
            _rollHelper = rollHelper ?? throw new ArgumentNullException(nameof(rollHelper));
        }

        public override void Attack(Hero defensiveHero)
        {
            base.Attack(defensiveHero);
            if (!IsDied())
            {
                if (defensiveHero.Type == HeroTypes.Sword)
                {
                    CurrentHealthPoint = 0;
                }
                else
                {
                    defensiveHero.Defense(this);
                }
            }
        }

        public override void Defense(Hero offensiveHero)
        {
            base.Defense(offensiveHero);
            if (!IsDied())
            {
                if (offensiveHero.Type == HeroTypes.Rider)
                {
                    CurrentHealthPoint = 0;
                }
                if (offensiveHero.Type == HeroTypes.Archer)
                {
                    bool shouldDie = _rollHelper.Roll(0.4);
                    if (shouldDie)
                    {
                        CurrentHealthPoint = 0;
                    }
                }
            }
        }
    }
}