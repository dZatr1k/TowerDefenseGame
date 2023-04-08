using System.Collections;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private Wave[] _waves;
    [SerializeField] private EnemySpawner _spawner;

    private void Start()
    {
        StartCoroutine(StartLoop());
    }

    public IEnumerator StartLoop()
    {
        foreach (var wave in _waves)
        {
            StartCoroutine(wave.StartWave(_spawner));
            yield return new WaitForSeconds(wave.Durration);
        }
    }
}
