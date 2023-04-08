using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

    public void SpawnEnemy(Enemy enemy)
    {
        int randomPointNumber = Random.Range(0, _spawnPoints.Length);
        Instantiate(enemy, _spawnPoints[randomPointNumber].position, Quaternion.identity);
    }
}
