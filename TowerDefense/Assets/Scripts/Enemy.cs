using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] protected float Speed;

    private bool _isWalking = true;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Hero hero))
        {
            _isWalking = false;
            Attack(hero);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
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
}