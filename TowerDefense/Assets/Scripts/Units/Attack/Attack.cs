using System;
using System.Diagnostics;

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
                    UnityEngine.Debug.Log("damage must be positive");
                    //throw new ArgumentException("damage must be positive");
                _damage = value;
            }
        }

        public Attack() : this(0){}

        public Attack(int damage)
        {
            Damage = damage;
        }

        public abstract void AttackTo(Unit target);

        public static Attack GenerateAttack(AttackType type)
        {
            return GenerateAttack(type, 0);
        }

        public static Attack GenerateAttack(AttackType type, int startDamage)
        {
            switch (type)
            {
                case AttackType.DefaultAttack:
                    return new DefaultAttack(startDamage);
                case AttackType.ThrowAttack:
                    return new ThrowAttack(startDamage);
                default:
                    throw new ArgumentException("Unknown/NotImplemented AttackType");
            }
        }
    }
}