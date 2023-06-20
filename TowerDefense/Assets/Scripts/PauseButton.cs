using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void Pause() 
    {
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }
}
