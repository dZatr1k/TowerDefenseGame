using UnityEngine;

public class Swampy : Enemy
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Hero hero))
        {
            hero.Slow(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Hero hero) && other.isActiveAndEnabled)
        {
            hero.Slow(false);
        }
    }
}