using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsMenuController : MonoBehaviour
{

    [SerializeField] private GameObject _global;
    [SerializeField] private GameObject _voiture;
    [SerializeField] private GameObject _musique;
    [SerializeField] private GameObject _daltonien;
    [SerializeField] private GameObject _fullScreen;
    [SerializeField] private GameObject _driftMode;
    [SerializeField] private GameObject _playerPref;
    [SerializeField] private GameObject _retour;

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

    public void SetDriftMode()
    {
        int driftModeTemp = PlayerPrefs.GetInt("EnabledDriftMode");
        if(driftModeTemp > 0)
        {
            PlayerPrefs.SetInt("EnabledDriftMode", 0);
        }
        else
        {
            PlayerPrefs.SetInt("EnabledDriftMode", 1);
        }
    }

}
