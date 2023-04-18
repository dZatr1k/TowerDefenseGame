using UnityEngine;

public class NonAttackingHeroes : Hero
{
    protected void OnTriggerStay2D(Collider2D other) { }
    protected override void Attack(Enemy enemy) { }
}
