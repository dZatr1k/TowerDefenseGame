using UnityEngine;

public class ThrowingWeapon : MonoBehaviour
{
    [SerializeField] private float Speed = 2;

    protected int _damage;
    protected bool _isThrowed = false;
    protected SpriteRenderer _renderer;


    private void Start()
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
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            Attack(enemy);
        }

        if (!_renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
        Destroy(gameObject);
    }

    public void Throw() { _isThrowed = true; print("True"); }
}
