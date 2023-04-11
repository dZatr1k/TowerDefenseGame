using UnityEngine;

public class Archer : Thrower
{
    protected override void Start()
    {
        SetThrowRangeSettings();
        CreateCurrentWeapon();
    }
}
