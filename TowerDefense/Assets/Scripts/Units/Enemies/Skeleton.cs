using System.Collections;
using UnityEngine;
using Units.Heroes;

namespace Units.Enemies
{
    public class Skeleton : Enemy
    {
        [SerializeField] protected GameObject _weaponPrefab;
        protected Animator _weaponAnimator;
        protected GameObject _currentWeapon;

        protected GameObject _throwRange;
        protected BoxCollider2D _throwRangeCollider;

        protected Vector2 _colliderOffset = new Vector2(2.6f, 0.5f);
        protected Vector2 _colliderSize = new Vector2(5, 1);
        protected Vector3 _weaponSpawnPos = new Vector3(-0.8f, 0.4f, 0);
        protected Quaternion _weaponSpawnAngle = Quaternion.Euler(0, 0, -56);

        protected virtual void Start()
        {
            SetThrowRangeSettings();
            _currentWeapon = GetComponentInChildren<EnemyThrowingWeapon>().gameObject;
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
            if (other.TryGetComponent(out Hero hero) && IsRecharged && !other.isTrigger)
            {
                _isWalking = false;
                Attack(hero);
            }
        }
        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Hero hero) && !other.isTrigger)
            {
                _isWalking = true;
            }
        }

        protected override void Attack(Hero hero)
        {
            IsRecharged = false;
            Animator.SetTrigger("attack");
            if (_weaponAnimator && _currentWeapon)
            {
                _weaponAnimator.SetTrigger("throw");
                _currentWeapon.GetComponent<EnemyThrowingWeapon>()?.Throw();
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
}