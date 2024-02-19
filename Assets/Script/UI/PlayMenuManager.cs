using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayMenuManager : MonoBehaviour
{

    public GameObject PlayMenuMainContainer;
    public GameObject CourseSimpleContainer;
    public GameObject ChoixCarMenuContainer;
    public GameObject MissionMenuContainer;

    public void GoToCarMenu()
    {
        PlayMenuMainContainer.SetActive(false);
        ChoixCarMenuContainer.SetActive(true);
    }

    public void GoToTrackMenu()
    {
        CourseSimpleContainer.SetActive(true);
        //PlayMenuMainContainer.SetActive(false);
        ChoixCarMenuContainer.SetActive(false);
    }


    public void GoToMissionMenu()
    {
        PlayMenuMainContainer.SetActive(false);
        MissionMenuContainer.SetActive(true);
    }

    public void Return_to_PlayMenu ()
    {

        //SI on etait dans le menu ChoixCarmenuContainer
        if (ChoixCarMenuContainer.activeSelf == true)
        {
            ChoixCarMenuContainer.SetActive(false);
            PlayMenuMainContainer.SetActive(true);
            
        }
        //Si on était dans le Menu Course et qu'on retourne en arrière
        if (CourseSimpleContainer.activeSelf == true)
        {
            ChoixCarMenuContainer.SetActive(true);
            CourseSimpleContainer.SetActive(false);
            //PlayMenuMainContainer.SetActive(false);
        }

        if (MissionMenuContainer.activeSelf == true)
        {
            PlayMenuMainContainer.SetActive(true);
            MissionMenuContainer.SetActive(false);
        }
    }
}
