using System.Collections;
using UnityEngine;
using Units.Enemies;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyList;

    public IEnumerator SpawnEnemies(Enemy[] enemies)
    {
        _spawnPoints.Shuffle();

        for (int i = 0; i < enemies.Length; i++)
        {
            Instantiate(enemies[i], _spawnPoints[i % 5].position, Quaternion.identity, _enemyList.transform);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
