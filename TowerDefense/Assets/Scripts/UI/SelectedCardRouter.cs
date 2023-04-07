using UnityEngine;

public class SelectedCardRouter : MonoBehaviour
{
    [SerializeField] private HeroPlacer _heroPlacer;
    
    private Card _lastSelectedCard;

    public void ChangeSelectedHero(Card selectedCard)
    {
        _heroPlacer.SetTypeOfHero(selectedCard.HeroPrefab);
        if (_lastSelectedCard != null)
            _lastSelectedCard.Deselect();
        _lastSelectedCard = selectedCard;
    }

    public void RemoveSelectedHero()
    {
        _heroPlacer.RemoveTypeOfHero();
        _lastSelectedCard = null;
    }
}
