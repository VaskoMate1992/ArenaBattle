using ArenaBattle.Heroes;
using ArenaBattle.Heroes.Enums;
using Moq;

namespace ArenaBattle.UnitTests.Heroes
{
    [Trait("TestType", "NormalTest")]
    public class SwordTests : BaseHeroTests
    {
        [Theory(DisplayName = "Should attack the other hero")]
        [InlineData(HeroTypes.Sword)]
        [InlineData(HeroTypes.Archer)]
        public void Should_Attack_The_Other_Hero(HeroTypes defensiveHeroType)
        {
            // Arrange
            var target = new Sword(Guid.NewGuid(), 120);
            var defensiveHero = GetDefensiveHero(defensiveHeroType);

            // Act
            target.Attack(defensiveHero);

            // Assert
            Assert.Equal(0, defensiveHero.CurrentHealthPoint);
            Assert.NotEqual(0, target.CurrentHealthPoint);
            RollHelper.Verify(x => x.Roll(It.IsAny<double>()), Times.Never);
        }

        [Fact(DisplayName = "Should attack sword to rider and nothing happened")]
        public void Should_Attack_Sword_To_Rider_And_Nothing_Happened()
        {
            // Arrange
            var target = new Sword(Guid.NewGuid(), 120);
            var defensiveHero = GetDefensiveHero(HeroTypes.Rider);

            // Act
            target.Attack(defensiveHero);

            // Assert
            Assert.NotEqual(0, defensiveHero.CurrentHealthPoint);
            Assert.NotEqual(0, target.CurrentHealthPoint);
            RollHelper.Verify(x => x.Roll(It.IsAny<double>()), Times.Never);
        }
    }
}