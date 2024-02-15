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

}
