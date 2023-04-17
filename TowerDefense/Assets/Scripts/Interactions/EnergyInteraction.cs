using UnityEngine;

public class EnergyInteraction : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 10f, layerMask: LayerMask.GetMask("Energy"));

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.TryGetComponent(out Energy energy))
                {
                    energy.Collect();
                }
            }
        }
    }
}
