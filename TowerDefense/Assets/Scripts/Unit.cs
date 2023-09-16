using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Units.Attacks;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        public UnityAction OnDied;

        [Header("Personal settings")]
        [SerializeField] protected int _health;

        [Header("Attack settings")]
        [SerializeField] protected AttackType _attackType;
        [SerializeField] protected int _damage;
        [SerializeField] protected float _rechargeTime;

        protected Attack _attack;
        protected bool _isRecharged = true;
        protected Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _attack = Attack.GenerateAttack(_attackType, _damage);
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
                StartCoroutine(Die());
            else
                _animator.SetTrigger("damaged");
        }

        public virtual void Stun(float time)
        {
            StartCoroutine(WaitForSeconds(time));
        }

        protected IEnumerator Die(float dieAnimatoinTime)
        {
            _animator.SetTrigger("die");
            yield return new WaitForSeconds(dieAnimatoinTime);
            OnDied?.Invoke();
            Destroy(gameObject);
            yield return null;

        }

        protected virtual IEnumerator Die()
        {
            _animator.SetTrigger("die");
            yield return new WaitForSeconds(0.3f);
            OnDied?.Invoke();
            Destroy(gameObject);
            yield return null;
        }

        protected virtual IEnumerator Recharge()
        {
            yield return new WaitForSeconds(_rechargeTime);
            _isRecharged = true;
        }

        protected virtual IEnumerator WaitForSeconds(float time)
        {
            yield return new WaitForSeconds(time);
        }
    }
}