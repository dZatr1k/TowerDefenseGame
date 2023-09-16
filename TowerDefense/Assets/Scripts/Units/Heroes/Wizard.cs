using System.Collections;
using UnityEngine;

namespace Units.Heroes
{
    public class Wizard : NonAttackingHeroes
    {
        [SerializeField] private GameObject _energy;
        [SerializeField] private Transform _energySpawnPoint;
        [Space]
        [SerializeField] private float _minRecargeTime = 10;
        [SerializeField] private float _maxRecargeTime = 15;

        private void Update()
        {
            if (_isRecharged)
                StartCoroutine(SpawnEnergy());
        }


        private IEnumerator SpawnEnergy()
        {
            if (_energySpawnPoint.transform.childCount == 0)
            {
                _isRecharged = false;
                float rechargeTime = Random.Range(_minRecargeTime, _maxRecargeTime);
                yield return new WaitForSeconds(rechargeTime);
                Instantiate(_energy, _energySpawnPoint.position, Quaternion.identity, _energySpawnPoint);
                _isRecharged = true;
            }
        }
    }
}
