using UnityEngine;

public class HeroPlacer : MonoBehaviour
{
    [SerializeField] private GameObject _typeOfHero;
    [SerializeField] private GameObject _heroList;

    private void OnEnable()
    {
        InterectionChecker.OnCellClick += SetHero;
    }

    private void OnDisable()
    {
        InterectionChecker.OnCellClick -= SetHero;
    }

    private void SetHero(Cell cell)
    {
        if (!cell.Hero)
        {
            
            GameObject heroObject = Instantiate(_typeOfHero, cell.SpawnPoint.transform.position, Quaternion.identity, _heroList.transform);
            cell.SetHero(heroObject.GetComponent<Hero>());
        }
    }

    public void SetTypeOfHero(GameObject typeOfHero)
    {  
        if (_typeOfHero.GetComponent<Hero>())
        {
            _typeOfHero = typeOfHero;
        }
    }
}
