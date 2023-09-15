using UnityEngine;

namespace Units.Heroes
{
    public class Archer : Thrower
{
    protected override void Start()
    {
        SetThrowRangeSettings();
        SetSpawnInfo(_weaponSpawnPos, Quaternion.identity);
        CreateCurrentWeapon();
    }
}
}