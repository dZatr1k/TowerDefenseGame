using UnityEngine;
using UnityEngine.UI;

public class SettingsChecker : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;

    private void Awake()
    {
        _musicSlider.value = SettingsData.MusicVolume;
        _soundSlider.value = SettingsData.SoundVolume;
    }

    public void ChangeMusicVolume(float amount)
    {
        SettingsData.MusicVolume = amount;
        var music = FindObjectOfType<Music>();
        if (music != null)
            music.Source.volume = amount;
    }

    public void ChangeSoundVolume(float amount)
    {
        SettingsData.SoundVolume = amount;
    }
}
