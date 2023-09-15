using UnityEngine;
using Units.Enemies;
using Units.Heroes;

public class EnemyThrowingWeapon : MonoBehaviour
{
    [SerializeField] protected float Speed = 4;

    protected int _damage;
    protected bool _isThrowed = false;


    protected virtual void Start()
    {
        _damage = GetComponentInParent<Enemy>().GetDamageInfo;
    }

    private void Update()
    {
        if (_isThrowed)
        {
            transform.position += Vector3.right * (Speed * Time.deltaTime);
        }
    }
    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Hero hero))
        {
            Attack(hero);
        }
        if (col.gameObject.tag == "WeaponBlocker")
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Attack(Hero hero)
    {
        hero.TakeDamage(_damage);
        Destroy(gameObject);
    }

    public void Throw() { _isThrowed = true; }
}
