using System.Collections;
using UnityEngine;

public class Thrower : Hero
{
    [SerializeField] GameObject _weaponPrefab;
    private Animator _weaponAnimator;
    private GameObject _currentWeapon;

    private GameObject _throwRange;
    private BoxCollider2D _throwRangeCollider;

    private Vector2 _colliderOffset = new Vector2(6f, 0.55f);
    private Vector2 _colliderSize = new Vector2(12, 1);
    private Vector3 _weaponSpawnPos = new Vector3(0.85f, 0.4f, 0);
    private Quaternion _weaponSpawnAngle = Quaternion.Euler(0, 0, -67);

    public int GetDamageInfo => Damage;

    private void Start()
    {
        _currentWeapon = GetComponentInChildren<ThrowingWeapon>().gameObject;
        _weaponAnimator = _currentWeapon.GetComponentInChildren<Animator>();


        _throwRange = new GameObject("TrowRange");
        _throwRange.transform.position = Vector2.zero;
        _throwRange.transform.SetParent(transform, false);
       

        _throwRangeCollider = _throwRange.AddComponent<BoxCollider2D>();
        _throwRangeCollider.isTrigger = true;
        _throwRangeCollider.offset = _colliderOffset;
        _throwRangeCollider.size = _colliderSize;

    }

    protected override void Attack(Enemy enemy)
    {
        IsRecharged = false;    
        Animator.SetTrigger("attack");
        _weaponAnimator.SetTrigger("throw");
        _currentWeapon.GetComponent<ThrowingWeapon>().Throw();
        StartCoroutine(Recharge());
    }

    protected override IEnumerator Recharge()
    {
        yield return new WaitForSeconds(RechargeTime);
        IsRecharged = true;
        _currentWeapon = Instantiate(_weaponPrefab, transform.position + _weaponSpawnPos, _weaponSpawnAngle, transform);
        _weaponAnimator = _currentWeapon.GetComponentInChildren<Animator>();
    }
}
