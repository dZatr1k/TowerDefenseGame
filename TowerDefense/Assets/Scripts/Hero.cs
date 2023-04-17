using System;
using UnityEngine;

public class Hero : Unit
{
    [SerializeField] private float _reloadTime = 1.5f;
    [SerializeField] private int _cost;
    private bool isSlowed = false;

    public int Cost => _cost;
    public float ReloadTime => _reloadTime;
    public event Action OnHeroDie;

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

    public void Slow(bool slow)
    {
        if (isSlowed && !slow)
        {
            print(gameObject.name + " Unslowed");
            RechargeTime /= 2;
            isSlowed = false;
        }
        else if (!isSlowed && slow)
        {
            print(gameObject.name + " Slowed");
            RechargeTime *= 2;
            isSlowed = true;
        }
    }
}