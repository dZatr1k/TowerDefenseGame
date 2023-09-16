using System;

namespace Units.Attacks
{
    public class DefaultAttack : Attack
    {
        public DefaultAttack() : this(0) { }
        public DefaultAttack(int damage) : base(damage) { }

        public override void AttackTo(Unit target)
        {
            throw new NotImplementedException();
        }
    }
}