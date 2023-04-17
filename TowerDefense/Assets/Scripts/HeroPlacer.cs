using System;
using UnityEngine;

public class HeroPlacer : MonoBehaviour
{
    [SerializeField] private GameObject _heroList;
    
    private GameObject _typeOfHero;

    private EnergyResources _energyResources;

    public static event Action OnHeroPlaced;

    private void Start()
    {
        _energyResources = FindObjectOfType<EnergyResources>();
    }

    private void OnEnable()
    {
        InteractionChecker.OnCellClick += PlaceHero;
    }

    private void OnDisable()
    {
        InteractionChecker.OnCellClick -= PlaceHero;
    }

    private void PlaceHero(Cell cell)
    {
        if (cell.Hero == null && _typeOfHero != null)
        {
            Hero hero= Instantiate(_typeOfHero, cell.SpawnPoint.transform.position, Quaternion.identity, _heroList.transform).GetComponent<Hero>();
            _energyResources.DecreaseBalance(hero.Cost);
            cell.SetHero(hero);
            OnHeroPlaced?.Invoke();
            
        }
    }

    public void SetTypeOfHero(GameObject typeOfHero)
    {  
        if (typeOfHero.TryGetComponent(out Hero hero))
        {
            _typeOfHero = typeOfHero;
        }
    }

    public void RemoveTypeOfHero()
    {
        _typeOfHero = null;
    }
}
