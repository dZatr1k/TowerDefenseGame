using UnityEngine;

public class Dino : Thrower
{
    private Quaternion _knifeSpawnAngle = Quaternion.Euler(0, 0, -67);

    protected override void Start()
    {
        SetThrowRangeSettings();
        _currentWeapon = GetComponentInChildren<ThrowingWeapon>().gameObject;
        _weaponAnimator = _currentWeapon.GetComponentInChildren<Animator>();
        SetSpawnInfo(_weaponSpawnPos, _knifeSpawnAngle);
    }
}
