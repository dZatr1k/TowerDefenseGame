using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;
using Units.Heroes;

public class MenuCard : MonoBehaviour, IPointerClickHandler
{
    public static UnityAction OnCardClick;

    [SerializeField] private GameObject _cardPoints;
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private Image _heroImage;

    private TextMeshProUGUI _heroCostText;
    private CardPoint[] _points;
    private RectTransform _rectTransform;
    private CardPoint _selectedPoint;
    private Vector3 _startPosition;

    private void Start()
    {
        _heroCostText = GetComponentInChildren<TextMeshProUGUI>();
        if(_heroPrefab.TryGetComponent(out Hero hero))
            _heroCostText.text = hero.Cost.ToString();

        _heroImage.sprite = _heroPrefab.GetComponent<SpriteRenderer>().sprite;
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.position;
        _points = _cardPoints.GetComponentsInChildren<CardPoint>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_selectedPoint == null) 
        {
            for (int i = 0; i < _points.Length; i++)
            {
                if (_points[i].IsOccupied == false)
                {
                    _rectTransform.DOMove(_points[i].RectTransform.position, 0.1f);
                    _points[i].IsOccupied = true;
                    _selectedPoint = _points[i];
                    _selectedPoint.SetHeroPrefab(_heroPrefab);
                    break;
                }
            }
        }
        else
        {
            _rectTransform.DOMove(_startPosition, 0.1f);
            _selectedPoint.IsOccupied = false;
            _selectedPoint.SetHeroPrefab(null);
            _selectedPoint = null;
        }

        OnCardClick?.Invoke();
    }
}
