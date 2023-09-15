using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Units.Heroes;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SelectedCardRouter _router;
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private Image _heroImage;
    [SerializeField] private GameObject _shade;

    private TextMeshProUGUI _heroCostText;
    private Slider _reloadSlider;
    private float _reloadTime;
    private bool _isSelected = false;
    private bool _isReloading = false;
    private bool _isAvailability = false;
    public GameObject HeroPrefab => _heroPrefab;

    private void OnEnable()
    {
        EnergyResources.OnBalanceChange += CheckAvailabilityStatus;
    }
    private void OnDisable()
    {
        EnergyResources.OnBalanceChange -= CheckAvailabilityStatus;
    }

    private void Start()
    {
        _heroCostText = GetComponentInChildren<TextMeshProUGUI>();

        _heroImage.sprite = _heroPrefab.GetComponent<SpriteRenderer>().sprite;

        if(_heroPrefab.TryGetComponent(out Hero hero))
        {
            _heroCostText.text = hero.Cost.ToString();
            _reloadTime = hero.ReloadTime;
        }
        _reloadSlider = GetComponentInChildren<Slider>();
    }

    public void ChangeHeroPrefab(GameObject newHero)
    {
        _heroPrefab = newHero;
    }

    public void OnPointerClick(PointerEventData eventData)
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

    public void Deselect()
    {
        _isSelected = false;
        if(_isReloading == false)
            _reloadSlider.value = 0;
    }

    public void Select()
    {
        if (_isAvailability && !_isReloading)
        {
            _isSelected = true;
            _router.ChangeSelectedHero(GetComponent<Card>());
            _reloadSlider.value = 1;
        }
    }

    private void CheckAvailabilityStatus(int balance)
    {
        if (_heroPrefab.GetComponent<Hero>().Cost <= balance)
        {
            _isAvailability = true;
            _shade.SetActive(false);
        }
            
        else
        {
            _isAvailability = false;
            _shade.SetActive(true);
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
