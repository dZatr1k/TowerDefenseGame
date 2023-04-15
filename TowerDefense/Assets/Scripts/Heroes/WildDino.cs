using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildDino : Thrower
{
    private List<GameObject> _currentWeapons = new List<GameObject>();
    private List<Animator> _currentWeaponsAnimators = new List<Animator>();

    protected override void Start()
    {
        SetThrowRangeSettings();
        ThrowingWeapon[] trowingWeapons = GetComponentsInChildren<ThrowingWeapon>();

        for (int i = 0; i < trowingWeapons.Length; i++)
        {
            GameObject tomahawk = trowingWeapons[i].gameObject;
            print(_currentWeapons);
            _currentWeapons.Add(tomahawk);

            _currentWeaponsAnimators.Add(tomahawk.GetComponentInChildren<Animator>());
        }
    }

    protected override void Attack(Enemy enemy)
    {
        IsRecharged = false;
        Animator.SetTrigger("attack");

        for (int i = 0; i < _currentWeapons.Count; i++)
        {
            _currentWeaponsAnimators[i].SetTrigger("throw");
            _currentWeapons[i].GetComponent<ThrowingWeapon>().Throw();
            StartCoroutine(IntervalThrows());
        }
        StartCoroutine(Recharge());
    }

    protected override void CreateCurrentWeapon()
    {
        GameObject newTomahawk = Instantiate(_weaponPrefab, transform.position + _weaponSpawnPos, _weaponSpawnAngle, transform);
        _currentWeapons.Add(newTomahawk);
        _currentWeaponsAnimators.Add(newTomahawk.GetComponentInChildren<Animator>());
    }

    protected override IEnumerator Recharge()
    {
        _currentWeapons = new List<GameObject>();
        _currentWeaponsAnimators = new List<Animator>();

        yield return new WaitForSeconds(RechargeTime);
        CreateCurrentWeapon();
        yield return new WaitForSeconds(0.7f);
        CreateCurrentWeapon();
        IsRecharged = true;
    }

    private IEnumerator IntervalThrows()
    {
        yield return new WaitForSeconds(1);
    }
}
