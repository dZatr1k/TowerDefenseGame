using UnityEngine;

public class Molot : HeroThrowingWeapon
{
    private float _stunTime;

    protected override void Start()
    {
        _damage = GetComponentInParent<Thrower>().GetDamageInfo;
        _stunTime = GetComponentInParent<Elf>().StunTime;
    }

    protected override void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
        enemy.Stun(_stunTime);
        Destroy(gameObject);
    }
}
