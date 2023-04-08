using UnityEngine;

public class SelectedCardRouter : MonoBehaviour
{
    [SerializeField] private HeroPlacer _heroPlacer;
    
    private Card _lastSelectedCard;

    private void OnEnable()
    {
        HeroPlacer.OnHeroPlaced += StartCardReloading;
    }

    private void OnDisable()
    {
        HeroPlacer.OnHeroPlaced -= StartCardReloading;
    }

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

    public void StartCardReloading()
    {
        StartCoroutine(_lastSelectedCard.Reload());
        RemoveSelectedHero();
    }
}
