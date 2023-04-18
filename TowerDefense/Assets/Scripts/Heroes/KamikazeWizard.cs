using System.Collections;
using UnityEngine;

public class KamikazeWizard : Hero
{
    [SerializeField] private BoxCollider2D _attackZoneCollider;
    [SerializeField] private float _delayBeforeBam = 0.5f;
    
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();

        StartCoroutine(WaitForSeconds(_delayBeforeBam));
    }

    protected void Attack(Collider2D[] hitColliders)
    {
        bool IsEnemy = false;
        Animator.SetTrigger("attack");
        foreach (var collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent(out Enemy enemy))
            {
                IsEnemy = true;
                enemy.TakeDamage(Damage);
            }
        }
        if (IsEnemy) 
        {
            _particleSystem.Play();
            StartCoroutine(Die());
        }
    }

    protected override IEnumerator WaitForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        _canComplate = true;
        Transform attackZoneTransform = _attackZoneCollider.gameObject.transform;
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(attackZoneTransform.position, _attackZoneCollider.size, 0, layerMask: LayerMask.GetMask("Default"));
        Attack(hitColliders);
    }
}
