using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameLoop : MonoBehaviour
{
    public static UnityAction OnWavesSpawned;

    private EnemySpawner _spawner;
    private Wave[] _waves;

    private void Start()
    {
        _waves = GetComponentsInChildren<Wave>();
        _spawner = FindObjectOfType<EnemySpawner>();

        StartCoroutine(StartLoop());
    }

    public IEnumerator StartLoop()
    {
        foreach (var wave in _waves)
        {
            StartCoroutine(wave.StartWave(_spawner));
            yield return new WaitForSeconds(wave.Duration);
        }

        OnWavesSpawned?.Invoke();
    }
}
