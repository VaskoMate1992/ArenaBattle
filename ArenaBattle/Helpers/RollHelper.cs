namespace ArenaBattle.Helpers
{
    public class RollHelper : IRollHelper
    {
        public bool Roll(double factor)
        {
            double nextDouble = Random.Shared.NextDouble();
            return factor >= nextDouble;
        }
    }
}