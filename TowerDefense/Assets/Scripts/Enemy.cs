using System.Collections;
using UnityEngine;
using Units.Heroes;

namespace Units.Enemies
{
    public class Enemy : Unit
    {
        [SerializeField] protected float Speed;
        [SerializeField] private AudioSource _source;

        protected bool _isWalking = true;
    
        public int GetDamageInfo => _damage;

        private void Start()
        {
            _source.volume = SettingsData.SoundVolume;

            _animator.SetTrigger("walk");
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
                _animator.SetTrigger("walk");
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
            if (_isRecharged)
            {
                _isRecharged = false;
                _animator.SetTrigger("attack");
                hero.TakeDamage(_damage);

                StartCoroutine(Recharge());
            }
        }

        protected override IEnumerator WaitForSeconds(float time)
        {
            _isWalking = false;
            yield return new WaitForSeconds(time);
            _isWalking = true;
        }

        public new void TakeDamage(int damage)
        {
            _source.Play();
            base.TakeDamage(damage);
        }
    }
}