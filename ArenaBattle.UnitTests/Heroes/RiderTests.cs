using ArenaBattle.Heroes;
using ArenaBattle.Heroes.Enums;
using Moq;

namespace ArenaBattle.UnitTests.Heroes
{
    [Trait("TestType", "NormalTest")]
    public class RiderTests : BaseHeroTests
    {
        [Theory(DisplayName = "Should attack the other hero")]
        [InlineData(HeroTypes.Rider)]
        [InlineData(HeroTypes.Archer)]
        public void Should_Attack_The_Other_Hero(HeroTypes defensiveHeroType)
        {
            // Arrange
            var target = new Rider(Guid.NewGuid(), 150, RollHelper.Object);
            var defensiveHero = GetDefensiveHero(defensiveHeroType);

            // Act
            target.Attack(defensiveHero);

            // Assert
            Assert.Equal(0, defensiveHero.CurrentHealthPoint);
            Assert.NotEqual(0, target.CurrentHealthPoint);
            RollHelper.Verify(x => x.Roll(It.IsAny<double>()), Times.Never);
        }

        [Fact(DisplayName = "Should attack rider to sword and offensive hero is dead")]
        public void Should_Attack_Rider_To_Sword_And_Offensive_Hero_Is_Dead()
        {
            // Arrange
            var target = new Rider(Guid.NewGuid(), 150, RollHelper.Object);
            var defensiveHero = GetDefensiveHero(HeroTypes.Sword);

            // Act
            target.Attack(defensiveHero);

            // Assert
            Assert.NotEqual(0, defensiveHero.CurrentHealthPoint);
            Assert.Equal(0, target.CurrentHealthPoint);
            RollHelper.Verify(x => x.Roll(It.IsAny<double>()), Times.Never);
        }
    }
}