using System.Collections;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private SubWave[] _subWaves;
    [SerializeField] private float _duration = 0;

    public float Durration => _duration;

    private void Awake()
    {
        foreach (var subWave in _subWaves)
        {
            _duration += subWave.Duration;
        }
    }

    public IEnumerator StartWave(EnemySpawner spawner)
    {
        foreach (var subWave in _subWaves)
        {
            StartCoroutine(subWave.StartSubWave(spawner));
            yield return new WaitForSeconds(subWave.Duration);
        }
    }
}
