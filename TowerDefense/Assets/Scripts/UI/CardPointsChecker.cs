using UnityEngine;
using UnityEngine.UI;

public class CardPointsChecker : MonoBehaviour
{
    [SerializeField] private Button _continueButton;

    private CardPoint[] _cardPoints;


    private void Start()
    {
        _cardPoints = GetComponentsInChildren<CardPoint>();
    }

    private void OnEnable()
    {
        MenuCard.OnCardClick += Check;
    }

    private void OnDisable()
    {
        MenuCard.OnCardClick -= Check;
    }

    public CardPoint[] GetCardPoints()
    {
        return _cardPoints;
    }

    public void Check()
    {
        int count;
        if (_cardPoints.Length >= UnlockCardsData.UnlockCardsCount)
            count = UnlockCardsData.UnlockCardsCount;
        else
            count = _cardPoints.Length;
        for (int i = 0; i < count; i++)
        {
            if (_cardPoints[i].IsOccupied == false) 
            {
                _continueButton.interactable = false;
                return;
            }
        }
        _continueButton.interactable = true;
    }
}
