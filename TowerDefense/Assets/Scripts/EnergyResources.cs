using System;
using TMPro;
using UnityEngine;

public class EnergyResources : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resourcesPreview;
    private int _energyResources = 10;

    public event Action<int> OnBalanceChange;

    private void Start()
    {
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
