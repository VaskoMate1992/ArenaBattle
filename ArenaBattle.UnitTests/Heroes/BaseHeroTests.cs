using ArenaBattle.Helpers;
using ArenaBattle.Heroes;
using ArenaBattle.Heroes.Enums;
using Moq;

namespace ArenaBattle.UnitTests.Heroes
{
    public abstract class BaseHeroTests
    {
        protected readonly Mock<IRollHelper> RollHelper = new Mock<IRollHelper>(MockBehavior.Strict);

        protected Hero GetDefensiveHero(HeroTypes defensiveHeroType)
        {
            return defensiveHeroType switch
            {
                HeroTypes.Archer => new Archer(Guid.NewGuid(), 100),
                HeroTypes.Rider => new Rider(Guid.NewGuid(), 150, RollHelper.Object),
                HeroTypes.Sword => new Sword(Guid.NewGuid(), 120),
                _ => throw new ArgumentOutOfRangeException(nameof(defensiveHeroType)),
            };
        }
    }
}