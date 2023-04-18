using System.Collections;
using UnityEngine;

public class EnergySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _energyPrefab;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    private void Start()
    {
        StartCoroutine(SpawnEhergy());
    }

    private IEnumerator SpawnEhergy()
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
            var x = Random.Range(_firstPoint.position.x, _secondPoint.position.x);
            var y = Random.Range(_firstPoint.position.y, _secondPoint.position.y);
            var energyPosition = new Vector3(x, y, 0);
            Instantiate(_energyPrefab, energyPosition, Quaternion.identity);
        }
    }
}
