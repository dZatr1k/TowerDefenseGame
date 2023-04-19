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

    private void OnCollisionStay2D(Collision2D collision) { }

    protected void Attack(Collider2D[] hitColliders)
    {
        Animator.SetTrigger("attack");
        _particleSystem.Play();
        foreach (var collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent(out Enemy enemy))
                enemy.TakeDamage(Damage);
        }
        StartCoroutine(Die(0.2f));
    }

    protected override IEnumerator WaitForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        Transform attackZoneTransform = _attackZoneCollider.gameObject.transform;
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(attackZoneTransform.position, _attackZoneCollider.size, 0, layerMask: LayerMask.GetMask("Default"));
        Attack(hitColliders);
        yield return null;
    }
}
