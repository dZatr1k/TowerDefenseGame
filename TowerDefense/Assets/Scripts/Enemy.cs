using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Unit
{
    [SerializeField] protected float Speed;

    protected bool _isWalking = true;
    
    public int GetDamageInfo => Damage;

    private void Start()
    {
        Animator.SetTrigger("walk");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Hero hero))
        {
            _isWalking = false;
            Attack(hero);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Hero hero))
        {
            _isWalking = true;
            Animator.SetTrigger("walk");
        }
    }

    private void Update()
    {
        if (_isWalking)
        {
            transform.position += Vector3.left * (Speed * Time.deltaTime);
        }
    }

    protected virtual void Attack(Hero hero)
    {
        if (IsRecharged)
        {
            IsRecharged = false;
            Animator.SetTrigger("attack");
            hero.TakeDamage(Damage);

            StartCoroutine(Recharge());
        }
    }

    protected override IEnumerator StopForSeconds(float time)
    {
        _isWalking = false;
        yield return new WaitForSeconds(time);
        _isWalking = true;
    }
}