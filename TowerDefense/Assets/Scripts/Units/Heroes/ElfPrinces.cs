using System;
using System.Collections;
using UnityEngine;

namespace Units.Heroes
{
    public class ElfPrinces : Hero
    {
        [SerializeField] [Range(0f, 1f)] private float _boostEffect;
        [SerializeField] private float _lifeTime = 5;

        public static Action<float> OnElfPrincesEnable;
        public static Action OnElfPrincesDisable;

        private void OnEnable()
        {
            HeroPlacer.OnHeroPlaced += Boost;
        }

        private void OnDisable()
        {
            HeroPlacer.OnHeroPlaced -= Boost;
        }

        private void Start()
        {
            Boost();
            StartCoroutine(DeathCountdown());
        }

        private void Boost()
        {
            OnElfPrincesEnable?.Invoke(_boostEffect);
        }

        private IEnumerator DeathCountdown()
        {
            yield return new WaitForSeconds(_lifeTime);
            StartCoroutine(Die());
        }
        protected override IEnumerator Die()
        {
            OnElfPrincesDisable?.Invoke();
            _animator.SetTrigger("die");
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
            OnDied?.Invoke();
            yield return null;
        }
    }
}
