using ArenaBattle.Heroes.Enums;

namespace ArenaBattle.Heroes
{
    public class Archer : Hero
    {
        public Archer(Guid id, int healthPoint) : base(id, healthPoint, HeroTypes.Archer)
        { }

        public override void Attack(Hero defensiveHero)
        {
            base.Attack(defensiveHero);
            if(!IsDied())
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
                    case HeroTypes.Sword:
                    case HeroTypes.Rider:
                    case HeroTypes.Archer:
                        CurrentHealthPoint = 0;
                        break;
                }
            }
        }
    }
}