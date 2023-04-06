using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoint;
    private Hero _hero;

    public GameObject SpawnPoint => _spawnPoint;
    public Hero Hero => _hero;

    public void SetHero(Hero hero)
    {
        _hero = hero;
        _hero.OnHeroDie += RemoveHero;      
    }

    private void RemoveHero()
    {
        _hero.OnHeroDie -= RemoveHero;
        _hero = null;
    }

}
