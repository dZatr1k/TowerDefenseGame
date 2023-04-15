using System;
using UnityEngine;

public class EnergyBalance : MonoBehaviour
{
    private uint _energyBalance;

    static public event Action<uint> OnBalanceChange;

    public void IncreaseBalance(uint amount)
    {
        _energyBalance += amount;
        OnBalanceChange?.Invoke(_energyBalance);
    }

    public void SubtractBalance(uint amount)
    {
        if (_energyBalance - amount >= 0)
        {
            _energyBalance -= amount;
            OnBalanceChange?.Invoke(_energyBalance);
        }
    }
}
