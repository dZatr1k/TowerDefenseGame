using System;
using UnityEngine;
using Units.Heroes;

public class HeroPlacer : MonoBehaviour
{
    [SerializeField] private GameObject _heroList;  
    private GameObject _typeOfHero;

    public static event Action OnHeroPlaced;

    private void OnEnable()
    {
        Cell.OnCellClick += PlaceHero;
    }

    private void OnDisable()
    {
        Cell.OnCellClick -= PlaceHero;
    }

    private void PlaceHero(Cell cell)
    {
        if (cell.Hero == null && _typeOfHero != null)
        {
            Hero hero= Instantiate(_typeOfHero, cell.SpawnPoint.transform.position, Quaternion.identity, _heroList.transform).GetComponent<Hero>();
            EnergyResources.singleton.DecreaseBalance(hero.Cost);
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
