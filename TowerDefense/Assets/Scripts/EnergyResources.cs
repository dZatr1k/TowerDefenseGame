using System;
using TMPro;
using UnityEngine;

public class EnergyResources : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resourcesPreview;
    private int _energyBalance = 2;

    public static event Action<int> OnBalanceChange;

    public static EnergyResources singleton { get; private set; }

    private void Awake()
    {
        singleton = this;
        UpdateCounter(_energyBalance);
    }

    private void OnEnable()
    {
        OnBalanceChange += UpdateCounter;
    }
    private void OnDisable()
    {
        OnBalanceChange -= UpdateCounter;
    }

    private void Start()
    {
        OnBalanceChange?.Invoke(_energyBalance);
    }

    public void IncreaseBalance(int amount)
    {
        if (amount >= 0)
        {
            _energyBalance += amount;
            OnBalanceChange?.Invoke(_energyBalance);
        }

    }

    //public bool TrySelect(int amount)
    //{
    //    if (_energyResources - amount >= 0 && amount >= 0)
    //        return true;
    //    return false;
    //}

    public void DecreaseBalance(int amount)
    {
        if (_energyBalance - amount >= 0 && amount >= 0)
        {
            _energyBalance -= amount;
            OnBalanceChange?.Invoke(_energyBalance);
        }
    }

    private void UpdateCounter(int amount)
    {
        _resourcesPreview.text = amount.ToString();
    }
}
