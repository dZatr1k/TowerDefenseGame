using UnityEngine;

public class LevelDataChanger : MonoBehaviour
{
    public void ChangeWavePrefab(GameObject leveWaves)
    {
        LevelData.LevelWavesPrefab = leveWaves;
    }

    public void ChangeRewardPrefab(GameObject levelReward)
    {
        LevelData.LevelRewardPrefab = levelReward;
    }
}
