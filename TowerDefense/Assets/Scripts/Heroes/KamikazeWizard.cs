using System.Collections;
using UnityEngine;

public class KamikazeWizard : Hero
{
    [SerializeField] private BoxCollider2D _attackZoneCollider;
    [SerializeField] private float _delayBeforeBam = 0.5f;
    private bool _canComplate = false;

    private void OnCollisionStay2D(Collision2D collision) { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(WaitForSeconds(_delayBeforeBam));
        if (_canComplate)
        {
            Transform attackZoneTransform = _attackZoneCollider.gameObject.transform;
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(attackZoneTransform.position, _attackZoneCollider.size, 0, layerMask: LayerMask.GetMask("Default"));
            Attack(hitColliders);
        }
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
        if(IsEnemy)
            StartCoroutine(Die());
    }

    protected override IEnumerator WaitForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        _canComplate = true;
    }
}
