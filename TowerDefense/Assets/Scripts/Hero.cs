using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy) && IsRecharged)
        {
            Attack(enemy);
        }
    }

    protected virtual void Attack(Unit unit)
    {
        IsRecharged = false;
        Animator.SetTrigger("attack");
        unit.TakeDamage(Damage);
        StartCoroutine(Recharge());
    }
}