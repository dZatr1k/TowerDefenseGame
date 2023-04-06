using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    // private Transform _transform;
    //
    // private void Start()
    // {
    //     _transform = GetComponent<Transform>();
    //     StartCoroutine(Walk());
    // }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Hero hero))
        {
            // StopCoroutine(Walk());
            Attack(hero);
        }
    }

    protected virtual void Attack(Unit unit)
    {
        if (IsRecharged)
        {
            IsRecharged = false;
            Animator.SetTrigger("attack");
            if (unit.TakeDamage(Damage))
            {
                // StartCoroutine(Walk());
            }
            StartCoroutine(Recharge());
        }
    }
    
    // private IEnumerator Walk()
    // {
    //     _transform.Translate(Vector3.left * Speed);
    //     StartCoroutine(Walk());
    //     return null;
    // }
}