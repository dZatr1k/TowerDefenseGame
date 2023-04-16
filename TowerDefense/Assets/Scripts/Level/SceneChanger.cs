using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadHeroPanel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("HeroSelectMenu");
    }

    public void LoadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
