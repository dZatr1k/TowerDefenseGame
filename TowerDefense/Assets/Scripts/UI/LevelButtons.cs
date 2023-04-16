using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    private Button[] _levelButtons;

    private void Start()
    {
        _levelButtons = GetComponentsInChildren<Button>();

        for (int i = 0; i < _levelButtons.Length; i++)
        {
            _levelButtons[i].interactable = false;
        }

        for (int i = 0; i < UnlockLevelData.UnlockLevelsCount; i++)
        {
            _levelButtons[i].interactable = true;
        }
    }
}
