using UnityEngine;

public class InterectionChecker : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit);
        }
    }
}
