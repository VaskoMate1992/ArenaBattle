namespace ArenaBattle.Configuration
{
    public interface IConfigManager
    {
        int HeroCount { get; }

        int ArcherHealthPoint { get; }

        int RiderHealthPoint { get; }

        int SwordHealthPoint { get; }
    }
}