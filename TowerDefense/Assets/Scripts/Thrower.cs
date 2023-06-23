using System.Collections;
using UnityEngine;

public class Thrower : Hero
{
    [SerializeField] protected GameObject _weaponPrefab;
    protected Animator _weaponAnimator;
    protected GameObject _currentWeapon;

    protected GameObject _throwRange;
    protected BoxCollider2D _throwRangeCollider;

    protected Vector2 _colliderOffset = new Vector2(9f, 0.55f);
    protected Vector2 _colliderSize = new Vector2(17, 1);
    protected Vector3 _weaponSpawnPos = new Vector3(0.85f, 0.4f, 0);
    protected Quaternion _weaponSpawnAngle = Quaternion.Euler(0, 0, -67);

    public int GetDamageInfo => Damage;

    protected virtual void Start()
    {
        SetThrowRangeSettings();
        _currentWeapon = GetComponentInChildren<HeroThrowingWeapon>().gameObject;
        _weaponAnimator = _currentWeapon.GetComponentInChildren<Animator>();

    }

    protected void SetThrowRangeSettings()
    {
        _throwRange = new GameObject("TrowRange");
        _throwRange.transform.position = Vector2.zero;
        _throwRange.transform.SetParent(transform, false);
        _throwRangeCollider = _throwRange.AddComponent<BoxCollider2D>();
        _throwRangeCollider.isTrigger = true;
        _throwRangeCollider.offset = _colliderOffset;
        _throwRangeCollider.size = _colliderSize;
    }
    
    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy) && IsRecharged && !other.isTrigger) 
        {
            Attack(enemy);
        }
    }

    protected override void Attack(Enemy enemy)
    {
        IsRecharged = false;
        Animator.SetTrigger("attack");
        if (_weaponAnimator && _currentWeapon)
        {
            _weaponAnimator.SetTrigger("throw");
            _currentWeapon.GetComponent<HeroThrowingWeapon>()?.Throw();
        }
        StartCoroutine(Recharge());
    }

    protected virtual void CreateCurrentWeapon()
    {
        _currentWeapon = Instantiate(_weaponPrefab, transform.position + _weaponSpawnPos, _weaponSpawnAngle, transform);
        _weaponAnimator = _currentWeapon.GetComponentInChildren<Animator>();
    }

    protected void SetSpawnInfo(Vector3 spawnPosByUnitPos, Quaternion spawnAngleByUnitAngle)
    {
        _weaponSpawnPos = spawnPosByUnitPos;
        _weaponSpawnAngle = spawnAngleByUnitAngle;
    }

    protected override IEnumerator Recharge()
    {
        yield return new WaitForSeconds(RechargeTime);
        IsRecharged = true;
        CreateCurrentWeapon();
    }
}
