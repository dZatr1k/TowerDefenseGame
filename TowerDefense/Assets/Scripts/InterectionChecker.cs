using System;
using UnityEngine;

public class InterectionChecker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _obj;

    static public event Action<Cell> OnCellClick;

    private void OnEnable()
    {
        OnCellClick += SetHero;
    }

    private void Update()
    {
        transform.position = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 10f);

            if (hit.collider != null)
            {
                if(hit.collider.gameObject.TryGetComponent(out Cell cell))
                {
                    OnCellClick?.Invoke(cell);
                }
            }
        }
    }

    private void SetHero(Cell cell)
    {
        Instantiate(_obj, cell.transform);
    }
}
