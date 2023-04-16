using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildDino : Thrower
{
    private List<GameObject> _currentWeapons = new List<GameObject>();
    private List<Animator> _currentWeaponsAnimators = new List<Animator>();
    protected Quaternion _secondWeaponSpawnAngle = Quaternion.Euler(0, 0, -80);
    protected Vector3 _secondWeaponSpawnPos = new Vector3(0.85f, 0.32f, 0);

    protected override void Start()
    {
        SetThrowRangeSettings();
        HeroThrowingWeapon[] trowingWeapons = GetComponentsInChildren<HeroThrowingWeapon>();

        for (int i = 0; i < trowingWeapons.Length; i++)
        {
            GameObject tomahawk = trowingWeapons[i].gameObject;
            _currentWeapons.Add(tomahawk);
            _currentWeaponsAnimators.Add(tomahawk.GetComponentInChildren<Animator>());
        }
    }

    protected override void Attack(Enemy enemy)
    {
        IsRecharged = false;
        Animator.SetTrigger("attack");
        StartCoroutine(IntervalThrows());
        StartCoroutine(Recharge());
    }

    protected override void CreateCurrentWeapon()
    {
        GameObject newTomahawk;
        if (_currentWeapons.Count == 0)
            newTomahawk = Instantiate(_weaponPrefab, transform.position + _weaponSpawnPos, _weaponSpawnAngle, transform);
        else
            newTomahawk = Instantiate(_weaponPrefab, transform.position + _secondWeaponSpawnPos, _secondWeaponSpawnAngle, transform);


        _currentWeapons.Add(newTomahawk);
        _currentWeaponsAnimators.Add(newTomahawk.GetComponentInChildren<Animator>());
    }

    protected override IEnumerator Recharge()
    {
        yield return new WaitForSeconds(RechargeTime);
        _currentWeapons = new List<GameObject>();
        _currentWeaponsAnimators = new List<Animator>();

        CreateCurrentWeapon();
        CreateCurrentWeapon();
        IsRecharged = true;
    }

    private IEnumerator IntervalThrows()
    {
        for (int i = 0; i < _currentWeapons.Count; i++)
        {
            _currentWeaponsAnimators[i].SetTrigger("throw");
            _currentWeapons[i].GetComponent<HeroThrowingWeapon>().Throw();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
