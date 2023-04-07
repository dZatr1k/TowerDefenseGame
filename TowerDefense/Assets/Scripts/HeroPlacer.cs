using UnityEngine;

public class HeroPlacer : MonoBehaviour
{
    [SerializeField] private GameObject _heroList;
    
    private GameObject _typeOfHero;

    private void OnEnable()
    {
        InterectionChecker.OnCellClick += PlaceHero;
    }

    private void OnDisable()
    {
        InterectionChecker.OnCellClick -= PlaceHero;
    }

    private void PlaceHero(Cell cell)
    {
        if (cell.Hero == null && _typeOfHero != null)
        {
            GameObject heroObject = Instantiate(_typeOfHero, cell.SpawnPoint.transform.position, Quaternion.identity, _heroList.transform);
            cell.SetHero(heroObject.GetComponent<Hero>());
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
