using ArenaBattle.Heroes.Enums;

namespace ArenaBattle.Heroes
{
    public abstract class Hero
    {
        public Guid Id { get; private set; }

        public HeroTypes Type { get; private set; }

        public int CurrentHealthPoint { get; protected set; }

        private int _previousHealthPoint;

        private readonly int _startHealthPoint;

        protected Hero(Guid id, int healthPoint, HeroTypes type)
        {
            Id = id;
            CurrentHealthPoint = healthPoint;
            _previousHealthPoint = healthPoint;
            _startHealthPoint = healthPoint;
            Type = type;
        }

        public virtual void Attack(Hero defensiveHero)
        {
            CurrentHealthDecrement();
        }

        public virtual void Defense(Hero offensiveHero)
        {
            CurrentHealthDecrement();
        }

        public bool IsDied()
        {
            return CurrentHealthPoint < (_startHealthPoint / 4) || CurrentHealthPoint == 0;
        }

        public void Rest()
        {
            _previousHealthPoint = CurrentHealthPoint;
            if ((CurrentHealthPoint + 10) > _startHealthPoint)
            {
                CurrentHealthPoint = _startHealthPoint;
            }
            else
            {
                CurrentHealthPoint += 10;
            }
        }

        public override string ToString()
        {
            return "\tType: " + Type.ToString() + 
                   "\r\n\tHP:" + _previousHealthPoint + "->" + CurrentHealthPoint;
        }

        #region PrivateHelperMethods

        private void CurrentHealthDecrement()
        {
            _previousHealthPoint = CurrentHealthPoint;
            CurrentHealthPoint = CurrentHealthPoint / 2;
            if (IsDied())
            {
                CurrentHealthPoint = 0;
            }
        }

        #endregion
    }
}