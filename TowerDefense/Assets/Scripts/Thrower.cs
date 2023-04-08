using UnityEngine;

public class Thrower : Hero
{
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
        _boxCollider2D.isTrigger = true;
        _boxCollider2D.offset = new Vector2(7.5f, 0.59375f);
        _boxCollider2D.size = new Vector2(14, 1);

    }

    protected override void Attack(Enemy enemy)
    {
        IsRecharged = false;
        Animator.SetTrigger("attack");
        StartCoroutine(Recharge());
        
    }
}
