using UnityEngine;

public class CardUnlocker : MonoBehaviour
{
    private MenuCard[] _menuCards;

    private void Start()
    {
        _menuCards = GetComponentsInChildren<MenuCard>();

        for (int i = 0; i < _menuCards.Length; i++)
        {
            _menuCards[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < UnlockCardsData.UnlockCardsCount; i++)
        {
            _menuCards[i].gameObject.SetActive(true);
        }
    }
}
