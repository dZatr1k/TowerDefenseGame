using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private void Start()
    {
        if(LevelData.LevelWavesPrefab)
            Instantiate(LevelData.LevelWavesPrefab);
    }
}
