using UnityEngine;

public class Dart : HeroThrowingWeapon
{
    protected override void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_damage);   
    }
}
