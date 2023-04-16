using UnityEngine;

public class LevelDataChanger : MonoBehaviour
{
    [SerializeField] private CardPointsChecker _cardPointsChecker;

    public void ChangeLevelIndex(int newIndex)
    {
        LevelData.LevelIndex = newIndex;
    }

    public void ChangeWavePrefab(GameObject leveWaves)
    {
        LevelData.LevelWavesPrefab = leveWaves;
    }

    public void ChangeRewardPrefab(GameObject levelReward)
    {
        LevelData.LevelRewardPrefab = levelReward;
    }

    public void ChangeHeroes()
    {
        if (_cardPointsChecker == null)
            return;

        var cardPoints = _cardPointsChecker.GetCardPoints();
        LevelData.HeroPrefabs = new GameObject[cardPoints.Length];

        for (int i = 0; i < cardPoints.Length; i++)
        {
            LevelData.HeroPrefabs[i] = cardPoints[i].GetHeroPrefab();
        }
    }
}
