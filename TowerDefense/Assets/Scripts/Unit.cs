using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Units.Attacks;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        public UnityAction OnDied;

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
            StartCoroutine(WaitForSeconds(time));
        }

        protected IEnumerator Die(float dieAnimatoinTime)
        {
            Animator.SetTrigger("die");
            yield return new WaitForSeconds(dieAnimatoinTime);
            OnDied?.Invoke();
            Destroy(gameObject);
            yield return null;

        }

        protected virtual IEnumerator Die()
        {
            Animator.SetTrigger("die");
            yield return new WaitForSeconds(0.3f);
            OnDied?.Invoke();
            Destroy(gameObject);
            yield return null;
        }

        protected virtual IEnumerator Recharge()
        {
            yield return new WaitForSeconds(RechargeTime);
            IsRecharged = true;
        }

        protected virtual IEnumerator WaitForSeconds(float time)
        {
            yield return new WaitForSeconds(time);
        }
    }

}