using UnityEngine;

public class Dart : ThrowingWeapon
{
    protected override void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_damage);   
    }
}
