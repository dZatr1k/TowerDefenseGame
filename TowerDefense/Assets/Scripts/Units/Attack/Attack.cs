using System;

namespace Units.Attacks
{
    public abstract class Attack
    {
        private int _damage;

        public virtual int Damage
        {
            get 
            { 
                return _damage; 
            }
            set
            {
                if (_damage <= 0)
                    throw new ArgumentException("damage must be positive");
                _damage = value;
            }
        }

        public abstract void AttackTo(Unit target);
    }
}