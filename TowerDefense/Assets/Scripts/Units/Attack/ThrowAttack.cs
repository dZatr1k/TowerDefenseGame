using System;

namespace Units.Attacks
{
    public class ThrowAttack : Attack
    {
        public ThrowAttack() : this(0) { }
        public ThrowAttack(int damage) : base(damage) { }

        public override void AttackTo(Unit target)
        {
            throw new NotImplementedException();
        }
    }
}