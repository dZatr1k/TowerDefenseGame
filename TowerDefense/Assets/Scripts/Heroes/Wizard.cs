using System.Collections;
using UnityEngine;

public class Wizard : Knight
{
    [SerializeField] private GameObject _energy;
    [SerializeField] private Transform _energySpawnPoint;
    [Space]
    [SerializeField] private float _minRecargeTime = 10;
    [SerializeField] private float _maxRecargeTime = 15;

    private void Update()
    {
        if (IsRecharged)
            StartCoroutine(SpawnEnergy());
    }


    private IEnumerator SpawnEnergy()
    {
        IsRecharged = false;
        float rechargeTime = Random.Range(_minRecargeTime, _maxRecargeTime);
        yield return new WaitForSeconds(rechargeTime);
        Instantiate(_energy, _energySpawnPoint.position, Quaternion.identity);
        IsRecharged = true;
    }
}
