using UnityEngine;
using Units.Enemies;

namespace Units.Heroes
{
    public class NonAttackingHeroes : Hero
    {
        protected void OnTriggerStay2D(Collider2D other) { }
        protected override void Attack(Enemy enemy) { }
    }
}