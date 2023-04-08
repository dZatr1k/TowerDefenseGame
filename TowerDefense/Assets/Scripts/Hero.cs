using System;
using UnityEngine;

public class Hero : Unit
{
    [SerializeField] private float _reloadTime = 1.5f;

    public float ReloadTime => _reloadTime;
    public event Action OnHeroDie;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy) && IsRecharged)
        {
            Attack(enemy);
        }
    }

    protected virtual void Attack(Enemy enemy)
    {
        IsRecharged = false;
        Animator.SetTrigger("attack");
        enemy.TakeDamage(Damage);
        StartCoroutine(Recharge());
    }
}