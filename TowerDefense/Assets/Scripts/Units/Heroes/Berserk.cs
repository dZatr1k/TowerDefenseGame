using System.Collections.Generic;
using UnityEngine;
using Units.Enemies;

namespace Units.Heroes
{
    public class Berserk : Hero
{
    private List<Enemy> _enemyList = new List<Enemy>();
    private Animator _swordAnimator;

    private void Start()
    {
        Sword sword = GetComponentInChildren<Sword>();
        _swordAnimator = sword.gameObject.GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision) { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            _enemyList.Add(enemy);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy) && _isRecharged)
            Attack();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            _enemyList.Remove(enemy);
    }

    protected void Attack()
    {
        _isRecharged = false;
        _animator.SetTrigger("attack");
        _swordAnimator.SetTrigger("attack");
        foreach (var enemy in _enemyList)
            enemy.TakeDamage(_damage);
        RemoveDeath();
        StartCoroutine(Recharge());
    }

    private void RemoveDeath()
    {
        foreach (var enemy in _enemyList)
        {
            if (!enemy)
                _enemyList.Remove(enemy);
        }
    }
}
}