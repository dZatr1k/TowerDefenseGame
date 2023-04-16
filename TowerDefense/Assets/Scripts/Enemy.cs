using System.Collections;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] protected float Speed;

    private bool _isWalking = true;

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
        }
    }

    private void Update()
    {
        if (_isWalking)
        {
            transform.position += Vector3.left * (Speed * Time.deltaTime);
        }
    }

    protected virtual void Attack(Unit unit)
    {
        if (IsRecharged)
        {
            IsRecharged = false;
            Animator.SetTrigger("attack");
            unit.TakeDamage(Damage);

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