using UnityEngine;

public class ThrowingWeapon : MonoBehaviour
{
    [SerializeField] protected float Speed = 4;

    protected int _damage;
    protected bool _isThrowed = false;


    protected virtual void Start()
    {
        _damage = GetComponentInParent<Thrower>().GetDamageInfo;
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
        if (col.gameObject.TryGetComponent(out Enemy enemy))
        {
            Attack(enemy);
        }
        if (col.gameObject.tag == "WeaponBlocker")
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
        Destroy(gameObject);
    }

    public void Throw() { _isThrowed = true; }
}
