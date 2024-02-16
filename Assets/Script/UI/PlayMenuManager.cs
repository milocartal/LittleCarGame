using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayMenuManager : MonoBehaviour
{

    public GameObject PlayMenuMainContainer;
    public GameObject CourseSimpleContainer;
    public GameObject ChoixCarMenuContainer;

    [SerializeField] private GameObject _grandPrix;
    [SerializeField] private GameObject _courseSimple;
    [SerializeField] private GameObject _chrono;
    [SerializeField] private GameObject _challenge;
    [SerializeField] private GameObject _tuto;
    [SerializeField] private GameObject _retour;
    [SerializeField] private GameObject _retourChoixCar;
    [SerializeField] private GameObject _circuit1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.MenuOpenCloseInput)
        {
            if (ChoixCarMenuContainer.activeSelf == true || CourseSimpleContainer.activeSelf == true)
            {
                Return_to_PlayMenu();
            }
        }
    }

    public void GoToChoixCarMenu()
    {
        PlayMenuMainContainer.SetActive(false);
        ChoixCarMenuContainer.SetActive(true);
        //EventSystem.current.SetSelectedGameObject();
    }

    public void Go_To_Choix_Car_For_Course_Simple_Menu()
    {
        CourseSimpleContainer.SetActive(true);
        //PlayMenuMainContainer.SetActive(false);
        ChoixCarMenuContainer.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_circuit1);
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
            EventSystem.current.SetSelectedGameObject(_grandPrix);

        }
        //Si on était dans le Menu Course et qu'on retourne en arrière
        if (CourseSimpleContainer.activeSelf == true)
        {
            ChoixCarMenuContainer.SetActive(true);
            CourseSimpleContainer.SetActive(false);
            //PlayMenuMainContainer.SetActive(false);
            //EventSystem.current.SetSelectedGameObject();
        }
    }
}
