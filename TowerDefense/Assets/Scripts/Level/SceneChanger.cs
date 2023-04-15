using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadHeroPanel()
    {
        SceneManager.LoadScene("HeroSelectMenu");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }
}
