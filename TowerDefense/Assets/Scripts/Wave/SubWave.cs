using UnityEngine;

public class SubWave : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _duration;

    public float Duration => _duration;

    public void StartSubWave(EnemySpawner spawner)
    {
        StartCoroutine(spawner.SpawnEnemies(_enemies));
    }
}
