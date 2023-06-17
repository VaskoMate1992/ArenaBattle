using ArenaBattle.Heroes;
using ArenaBattle.Heroes.Enums;
using Moq;

namespace ArenaBattle.UnitTests.Heroes
{
    [Trait("TestType", "NormalTest")]
    public class ArcherTests : BaseHeroTests
    {
        [Theory(DisplayName = "Should attack the other hero")]
        [InlineData(HeroTypes.Sword)]
        [InlineData(HeroTypes.Archer)]
        public void Should_Attack_The_Other_Hero(HeroTypes defensiveHeroType)
        {
            // Arrange
            var target = new Archer(Guid.NewGuid(), 100);
            var defensiveHero = GetDefensiveHero(defensiveHeroType);

            // Act
            target.Attack(defensiveHero);

            // Assert
            Assert.Equal(0, defensiveHero.CurrentHealthPoint);
            Assert.NotEqual(0, target.CurrentHealthPoint);
            RollHelper.Verify(x => x.Roll(It.IsAny<double>()), Times.Never);
        }

        [Fact(DisplayName = "Should attack archer to rider when rider dead")]
        public void Should_Attack_Archer_To_Rider_When_Rider_Dead()
        {
            // Arrange
            var target = new Archer(Guid.NewGuid(), 100);
            var defensiveHero = GetDefensiveHero(HeroTypes.Rider);
            RollHelper.Setup(x => x.Roll(It.IsAny<double>())).Returns(true);

            // Act
            target.Attack(defensiveHero);

            // Assert
            Assert.Equal(0, defensiveHero.CurrentHealthPoint);
            Assert.NotEqual(0, target.CurrentHealthPoint);
            RollHelper.Verify(x => x.Roll(It.Is<double>(val => val == 0.4)), Times.Once);
        }

        [Fact(DisplayName = "Should attack archer to rider when rider is not dead")]
        public void Should_Attack_Archer_To_Rider_When_Rider_Is_Not_Dead()
        {
            // Arrange
            var target = new Archer(Guid.NewGuid(), 100);
            var defensiveHero = GetDefensiveHero(HeroTypes.Rider);
            RollHelper.Setup(x => x.Roll(It.IsAny<double>())).Returns(false);

            // Act
            target.Attack(defensiveHero);

            // Assert
            Assert.NotEqual(0, defensiveHero.CurrentHealthPoint);
            RollHelper.Verify(x => x.Roll(It.Is<double>(val => val == 0.4)), Times.Once);
        }
    }
}