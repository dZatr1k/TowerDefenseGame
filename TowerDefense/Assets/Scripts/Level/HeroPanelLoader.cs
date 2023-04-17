using UnityEngine;

public class HeroPanelLoader : MonoBehaviour
{
    private Card[] _cards;

    private void Awake()
    {
        _cards = GetComponentsInChildren<Card>();

        for (int i = 0; i < _cards.Length; i++)
        {
            _cards[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < LevelData.HeroPrefabs.Length; i++)
        {
            _cards[i].gameObject.SetActive(true);
            _cards[i].ChangeHeroPrefab(LevelData.HeroPrefabs[i]);
        }
    }
}
