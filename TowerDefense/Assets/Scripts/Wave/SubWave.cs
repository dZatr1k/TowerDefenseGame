using System.Collections;
using UnityEngine;

public class SubWave : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _duration;

    public float Duration => _duration;

    public IEnumerator StartSubWave(EnemySpawner spawner)
    {
        foreach (var enemy in _enemies)
        {
            spawner.SpawnEnemy(enemy);
            yield return new WaitForSeconds(0.4f);
        }
    }
}
