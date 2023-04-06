using System;
using UnityEngine;

public class InterectionChecker : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    static public event Action<Cell> OnCellClick;

    private void Update()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 10f);

            if (hit.collider != null)
            {
                if(hit.collider.gameObject.TryGetComponent(out Cell cell))
                {
                    OnCellClick?.Invoke(cell);
                }
            }
        }
    }

}
