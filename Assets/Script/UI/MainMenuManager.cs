using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainMenuManager : MonoBehaviour
{

    string currentSceneName;
    public GameObject MainMenuContainer;
    public GameObject PlayMenuContainer;
    public GameObject OptionsMenuContainer;
    public GameObject PartyPlayContainer;

    [SerializeField] private GameObject _jouer;
    [SerializeField] private GameObject _option;
    [SerializeField] private GameObject _quitter;
    [SerializeField] private GameObject _grandPrix;
    [SerializeField] private GameObject _global;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        EventSystem.current.SetSelectedGameObject(_jouer);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.MenuOpenCloseInput)
        {
            if (PartyPlayContainer.activeSelf == true || OptionsMenuContainer.activeSelf == true)
            {
                Return_to_main_menu();
            }
        }
    }


    public void Play_Section ()
    {
        //Vu qu'on est plus dans le MainMenu on désactive
        MainMenuContainer.SetActive(false);
        //On active le bon container
        PlayMenuContainer.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_grandPrix);
    }

    public void Options_Sections ()
    {
        //Debug.Log("Options Menu");
        MainMenuContainer.SetActive(false);
        OptionsMenuContainer.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_global);
    }

    public void Quit_Section ()
    {
        Application.Quit();
    }

    //Quand on est dans Options ou Play et qu'on retourne dans le menu principal
    public void Return_to_main_menu ()
    {
        if (PlayMenuContainer.activeSelf == true)
        {
            PlayMenuContainer.SetActive(false);
        }
        if (OptionsMenuContainer.activeSelf == true)
        {
            OptionsMenuContainer.SetActive(false);
        }
        MainMenuContainer.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_jouer);
    }
}
