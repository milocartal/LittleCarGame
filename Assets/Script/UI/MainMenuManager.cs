using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{

    string currentSceneName;
    public GameObject MainMenuContainer;
    public GameObject PlayMenuContainer;
    public GameObject OptionsMenuContainer;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Play_Section ()
    {
        //Vu qu'on est plus dans le MainMenu on désactive
        MainMenuContainer.SetActive(false);
        //On active le bon container
        PlayMenuContainer.SetActive(true);
    }

    public void Options_Sections ()
    {
        //Debug.Log("Options Menu");
        MainMenuContainer.SetActive(false);
        OptionsMenuContainer.SetActive(true);
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
    }
}
