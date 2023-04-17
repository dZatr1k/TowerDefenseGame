using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SelectedCardRouter _router;
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private Image _heroImage;

    private Slider _reloadSlider;
    private float _reloadTime;
    private bool _isSelected = false;
    private bool _isReloading = false;

    private EnergyResources _energyResources;
    public GameObject HeroPrefab => _heroPrefab;
    

    private void Start()
    {
        _heroImage.sprite = _heroPrefab.GetComponent<SpriteRenderer>().sprite;

        if(_heroPrefab.TryGetComponent(out Hero hero))
        {
            _reloadTime = hero.ReloadTime;
        }
        _reloadSlider = GetComponentInChildren<Slider>();

        _energyResources = FindObjectOfType<EnergyResources>();
    }

    public void ChangeHeroPrefab(GameObject newHero)
    {
        _heroPrefab = newHero;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isReloading == false)
        {
            if (_isSelected)
            {
                Deselect();
                _router.RemoveSelectedHero();
            }
            else
            {
                Select();
            }
        }
    }

    public void Deselect()
    {
        _isSelected = false;
        if(_isReloading == false)
            _reloadSlider.value = 0;
    }

    public void Select()
    {
        if (_energyResources.TrySelect(_heroPrefab.GetComponent<Hero>().Cost))
        {
            _isSelected = true;
            _router.ChangeSelectedHero(GetComponent<Card>());
            _reloadSlider.value = 1;
        }
    }

    public IEnumerator Reload()
    {
        _isReloading = true;
        Deselect();

        float elapsedTime = 0;
        while (elapsedTime <= _reloadTime)
        {
            yield return new WaitForSeconds(0.05f);
            elapsedTime += 0.05f;
            _reloadSlider.value = 1 - elapsedTime / _reloadTime;
        }

        _isSelected = false;
        _isReloading = false;
    }
}
