using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, ISelectable, IPointerClickHandler
{
    [SerializeField] private Color _SelectedColor = Color.gray;
    [SerializeField] private SelectedCardRouter _router;
    [SerializeField] private GameObject _heroPrefab;

    private Image _cardImage;
    private bool _isSelected = false;

    public GameObject HeroPrefab => _heroPrefab;

    private void Start()
    {
        _cardImage = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isSelected)
            _router.RemoveSelectedHero();
        else
            Select();
    }

    public void Deselect()
    {
        _isSelected = false;
        _router.RemoveSelectedHero();
        _cardImage.color = Color.white;
    }

    public void Select()
    {
        _isSelected = true;
        _router.ChangeSelectedHero(GetComponent<Card>());
        _cardImage.color = _SelectedColor;
    }
}
