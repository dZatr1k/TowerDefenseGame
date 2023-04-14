using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MenuCard : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _cardPoints;
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private Image _heroImage;

    private CardPoint[] _points;
    private RectTransform _rectTransform;
    private CardPoint _selectedPoint;
    private Vector3 _startPosition;

    private void Start()
    {
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
                    return;
                }
            }
        }
        else
        {
            _rectTransform.DOMove(_startPosition, 0.1f);
            _selectedPoint.IsOccupied = false;
            _selectedPoint = null;
        }
    }
}
