using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    private void Start()
    {
        Destroy(FindObjectOfType<MenuMusic>().gameObject);
    }
}
