using System;
using TMPro;
using UnityEngine;

public class EnergyResources : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resourcesPreview;
    private int _energyResources = 2;

    public event Action<int> OnBalanceChange;

    public static EnergyResources singleton { get; private set; }

    private void Awake()
    {
        singleton = this;
        UpdateCounter(_energyResources);
    }

    private void OnEnable()
    {
        OnBalanceChange += UpdateCounter;
    }
    private void OnDisable()
    {
        OnBalanceChange -= UpdateCounter;
    }

    public void IncreaseBalance(int amount)
    {
        if (amount >= 0)
        {
            _energyResources += amount;
            OnBalanceChange?.Invoke(_energyResources);
        }

    }

    public bool TrySelect(int amount)
    {
        if (_energyResources - amount >= 0 && amount >= 0)
            return true;
        return false;
    }

    public void DecreaseBalance(int amount)
    {
        if (_energyResources - amount >= 0 && amount >= 0)
        {
            _energyResources -= amount;
            OnBalanceChange?.Invoke(_energyResources);
        }
    }

    private void UpdateCounter(int amount)
    {
        _resourcesPreview.text = amount.ToString();
    }
}
