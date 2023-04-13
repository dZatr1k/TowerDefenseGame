using UnityEngine;

public class ThrowingWeapon : MonoBehaviour
{
    [SerializeField] protected float Speed = 2;

    protected int _damage;
    protected bool _isThrowed = false;
    protected SpriteRenderer _renderer;


    protected virtual void Start()
    {
        _damage = GetComponentInParent<Thrower>().GetDamageInfo;
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isThrowed)
        {
            transform.position += Vector3.right * (Speed * Time.deltaTime);
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            Attack(enemy);
        }

        if (other.tag == "WeaponBlocker")
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
