using UnityEngine;

public class InterectionChecker : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        transform.position = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 10f);

            if (hit.collider != null)
            {
                hit.collider.gameObject.TryGetComponent(out SpriteRenderer renderer);
                renderer.color = Color.red;
            }
        }
    }
}
