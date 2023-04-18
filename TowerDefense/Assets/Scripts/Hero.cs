using System;
using UnityEngine;

public class Hero : Unit
{
    [SerializeField] private float _reloadTime = 1.5f;
    [SerializeField] private int _cost;
    [SerializeField] private AudioSource _source;

    private bool isSlowed = false;
    private float _standartRechargeTime;

    public int Cost => _cost;
    public float ReloadTime => _reloadTime;

    private void OnEnable()
    {
        _standartRechargeTime = RechargeTime;

        ElfPrinces.OnElfPrincesEnable += SetBoost;
        ElfPrinces.OnElfPrincesDisable += DiscardBoost;
    }

    private void OnDisable()
    {
        ElfPrinces.OnElfPrincesEnable -= SetBoost;
        ElfPrinces.OnElfPrincesDisable -= DiscardBoost;
    }

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
            RechargeTime = _standartRechargeTime;
            isSlowed = false;
        }
        else if (!isSlowed && slow)
        {
            print(gameObject.name + " Slowed");
            RechargeTime *= 1.5f;
            isSlowed = true;
        }
    }

    private void SetBoost(float boostPercent)
    {
        RechargeTime -= RechargeTime * boostPercent;
    }

    private void DiscardBoost()
    {
        RechargeTime = _standartRechargeTime;
    }

    public new void TakeDamage(int damage)
    {
        _source.Play();
        base.TakeDamage(damage);
    }
}