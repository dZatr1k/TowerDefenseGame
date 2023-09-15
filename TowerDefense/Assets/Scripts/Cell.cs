using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Units.Heroes;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _spawnPoint;
    private Hero _hero;

    public GameObject SpawnPoint => _spawnPoint;
    public Hero Hero => _hero;

    public static Action<Cell> OnCellClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCellClick?.Invoke(this);
    }

    public void SetHero(Hero hero)
    {
        _hero = hero;
        _hero.OnDied += RemoveHero;      
    }

    private void RemoveHero()
    {
        _hero.OnDied -= RemoveHero;
        _hero = null;
    }

}
