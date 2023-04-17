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
        int count;
        if(cardPoints.Length >= UnlockCardsData.UnlockCardsCount)
            count = UnlockCardsData.UnlockCardsCount;
        else
            count = cardPoints.Length;
        LevelData.HeroPrefabs = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            LevelData.HeroPrefabs[i] = cardPoints[i].GetHeroPrefab();
        }
    }
}
