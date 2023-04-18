using UnityEngine;

public class Molot : HeroThrowingWeapon
{
    private float _stunTime;
    private float _stunChance;

    protected override void Start()
    {
        _damage = GetComponentInParent<Thrower>().GetDamageInfo;
        var elf = GetComponentInParent<Elf>();
        _stunTime = elf.StunTime;
        _stunChance = elf.StunChance <= 100 ? elf.StunChance : 100;
    }

    protected override void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
        int chance = Random.Range(0, 100);
        if(chance < _stunChance)
        enemy.Stun(_stunTime);
        Destroy(gameObject);
    }
}
