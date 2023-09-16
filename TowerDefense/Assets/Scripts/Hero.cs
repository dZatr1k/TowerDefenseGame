using Units.Enemies;
using UnityEngine;

namespace Units.Heroes
{
    public class Hero : Unit
    {
        [SerializeField] private float _reloadTime = 1.5f;
        [SerializeField] private int _cost;
        [SerializeField] private AudioSource _source;

        private bool isSlowed = false;
        private float _standartRechargeTime;

        public int Cost => _cost;
        public float ReloadTime => _reloadTime;

        private void OnEnable()
        {
            _source.volume = SettingsData.SoundVolume;
            _standartRechargeTime = _rechargeTime;

            ElfPrinces.OnElfPrincesEnable += SetBoost;
            ElfPrinces.OnElfPrincesDisable += DiscardBoost;
        }

        private void OnDisable()
        {
            ElfPrinces.OnElfPrincesEnable -= SetBoost;
            ElfPrinces.OnElfPrincesDisable -= DiscardBoost;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Enemy enemy) && _isRecharged)
            {
                Attack(enemy);
            }
        }

        protected virtual void Attack(Enemy enemy)
        {
            _isRecharged = false;
            _animator.SetTrigger("attack");
            enemy.TakeDamage(_damage);
            StartCoroutine(Recharge());
        }

        public void Slow(bool slow)
        {
            if (isSlowed && !slow)
            {
                _rechargeTime = _standartRechargeTime;
                isSlowed = false;
            }
            else if (!isSlowed && slow)
            {
                print(gameObject.name + " Slowed");
                _rechargeTime *= 1.5f;
                isSlowed = true;
            }
        }

        private void SetBoost(float boostPercent)
        {
            _rechargeTime -= _rechargeTime * boostPercent;
        }

        private void DiscardBoost()
        {
            _rechargeTime = _standartRechargeTime;
        }

        public new void TakeDamage(int damage)
        {
            _source.Play();
            base.TakeDamage(damage);
        }
    }
}