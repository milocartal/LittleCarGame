using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayMenuManager : MonoBehaviour
{

    public GameObject PlayMenuMainContainer;
    public GameObject CourseSimpleContainer;
    public GameObject ChoixCarMenuContainer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToChoixCarMenu()
    {
        PlayMenuMainContainer.SetActive(false);
        ChoixCarMenuContainer.SetActive(true);
    }

    public void Go_To_Choix_Car_For_Course_Simple_Menu()
    {
        CourseSimpleContainer.SetActive(true);
        //PlayMenuMainContainer.SetActive(false);
        ChoixCarMenuContainer.SetActive(false);
    }

    

    public void Return_to_PlayMenu ()
    {
        //CourseSimpleContainer.SetActive(false);
        //PlayMenuMainContainer.SetActive(true);

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
    }
}
