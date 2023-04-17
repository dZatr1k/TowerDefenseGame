using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    private void Start()
    {
        var menuMusic = FindObjectOfType<MenuMusic>();
        if(menuMusic != null)
            Destroy(menuMusic.gameObject);
    }
}
