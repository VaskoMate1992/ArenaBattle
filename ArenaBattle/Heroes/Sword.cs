using ArenaBattle.Heroes.Enums;

namespace ArenaBattle.Heroes
{
    public class Sword : Hero
    {
        public Sword(Guid id, int healthPoint) : base(id, healthPoint, HeroTypes.Sword)
        { }

        public override void Attack(Hero defensiveHero)
        {
            base.Attack(defensiveHero);
            if (!IsDied())
            {
                defensiveHero.Defense(this);
            }
        }

        public override void Defense(Hero offensiveHero)
        {
            base.Defense(offensiveHero);
            if (!IsDied())
            {
                switch (offensiveHero.Type)
                {
                    case HeroTypes.Archer:
                    case HeroTypes.Sword:
                        CurrentHealthPoint = 0;
                        break;
                }
            }
        }
    }
}