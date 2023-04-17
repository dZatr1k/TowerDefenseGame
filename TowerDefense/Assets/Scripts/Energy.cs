using UnityEngine;
using DG.Tweening;

public class Energy : MonoBehaviour
{
    [SerializeField] private int _unitsEnergy = 1;
    private EnergyResources _energyResources;

    private void Awake()
    {
        _energyResources = FindObjectOfType<EnergyResources>();
        Destroy(gameObject, 5);
    }
    public void Collect()
    {
        _energyResources.IncreaseBalance(_unitsEnergy);
        //gameObject.transform.DOMove(_energyResources.gameObject.transform.position, 0.2f);
        Destroy(gameObject);
    }
}
