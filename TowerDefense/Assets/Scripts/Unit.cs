using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Unit : MonoBehaviour
{
    [SerializeField] protected int Health;
    [SerializeField] protected int Damage;
    [SerializeField] protected float RechargeTime;
    protected bool IsRecharged = true;

    protected Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public bool TakeDamage(int damage)
    {
        Health -= damage;
        print(gameObject.name + ": " + Health);
        
        if (Health <= 0)
        {
            StartCoroutine(Die());
            return true;
        }

        return false;
    }

    protected IEnumerator Die()
    {
        Animator.SetTrigger("die");
        print(gameObject.name + " died");
        print(0.2f);
        yield return new WaitForSeconds(Animator.GetCurrentAnimatorClipInfo(0).Length);
        Destroy(gameObject);
    }

    protected IEnumerator Recharge()
    {
        yield return new WaitForSeconds(RechargeTime);
        IsRecharged = true;
    }
}