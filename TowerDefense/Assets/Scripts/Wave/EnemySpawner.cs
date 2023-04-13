using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyList;

    public void SpawnEnemy(Enemy enemy)
    {
        int randomPointNumber = Random.Range(0, _spawnPoints.Length);
        Instantiate(enemy, _spawnPoints[randomPointNumber].position, Quaternion.identity, _enemyList.transform);
    }
}
