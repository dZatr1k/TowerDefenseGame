using UnityEngine;
using TMPro;

public class CardPoint : MonoBehaviour
{
    private RectTransform _rectTransform;
    private GameObject _heroPrefab;

    public RectTransform RectTransform => _rectTransform;
    public bool IsOccupied;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public GameObject GetHeroPrefab()
    {
        return _heroPrefab;
    }
    public void SetHeroPrefab(GameObject enemyPrefab)
    {
        _heroPrefab = enemyPrefab;
    }
}
