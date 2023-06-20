using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Energy : MonoBehaviour
{
    [SerializeField] private int _unitsEnergy = 2;
    [SerializeField] private AudioSource _source;
    private bool _isCollected = false;

    private EnergyResources _energyResources;

    private void Awake()
    {
        _energyResources = FindObjectOfType<EnergyResources>();
        if(!transform.parent)
            Destroy(gameObject, 5);
    }

    public void TryCollect()
    {
        if (!_isCollected)
        {
            _isCollected = true;
            _source.Play();
            _energyResources.IncreaseBalance(_unitsEnergy);
            gameObject.transform.DOMove(_energyResources.transform.position, 0.2f);
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
