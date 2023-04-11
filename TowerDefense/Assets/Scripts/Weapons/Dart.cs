using UnityEngine;

public class Dart : ThrowingWeapon
{
    private Enemy _enemy;

    protected override void Attack(Enemy enemy)
    {
        if (_enemy != enemy)
        {
            enemy.TakeDamage(_damage);
            _enemy = enemy;
        }     
    }
}
