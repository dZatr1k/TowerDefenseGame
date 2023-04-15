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

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
            StartCoroutine(Die());
        else
            Animator.SetTrigger("damaged");
    }

    public virtual void Stun(float time)
    {
        StartCoroutine(StopForSeconds(time));
    }

    protected IEnumerator Die()
    {
        Animator.SetTrigger("die");
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
        yield return null;
    }

    protected virtual IEnumerator Recharge()
    {
        yield return new WaitForSeconds(RechargeTime);
        IsRecharged = true;
    }

    protected virtual IEnumerator StopForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
    }
}