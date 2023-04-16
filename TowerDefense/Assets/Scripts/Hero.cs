using System;
using UnityEngine;

public class Hero : Unit
{
    [SerializeField] private float _reloadTime = 1.5f;

    public float ReloadTime => _reloadTime;
    public event Action<bool> OnSlowed;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) && IsRecharged)
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