using UnityEngine;

public class CardPoint : MonoBehaviour
{
    private RectTransform _rectTransform;

    public RectTransform RectTransform => _rectTransform;
    public bool IsOccupied;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
}
