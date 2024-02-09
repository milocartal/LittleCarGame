using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuController : MonoBehaviour
{
    public void setFullScreen(bool isFullScreen)
    {
        if (isFullScreen)
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        else
            Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    public void ErasePlayerPref()
    {
        PlayerPrefs.DeleteAll();
    }

}
