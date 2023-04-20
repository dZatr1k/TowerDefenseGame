using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource _source;

    public AudioSource Source => _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();

        _source.volume = SettingsData.MusicVolume;
    }
}
