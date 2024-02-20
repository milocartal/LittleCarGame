using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    string currentSceneName;
    //Récupérer la scène
    [SerializeField] private GameObject _continuer;
    [SerializeField] private GameObject _recommencer;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _quitter;

    void Start ()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }


    // Update is called once per frame
    void Update()
    {
        //Si on appuie sur Echap
        if (InputManager.instance.MenuOpenCloseInput)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        EventSystem.current.SetSelectedGameObject(null);
    }

    //Si on est en pause
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        //timeScale zéro : time freeze
        Time.timeScale = 0f;
        GameIsPaused = true;
        EventSystem.current.SetSelectedGameObject(_continuer);
    }

    public void Continuer ()
    {
        Resume();
    }

    public void Recommencer()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Menu()
    {
        Time.timeScale = 1.0f;
        GameManager.instance.SetRaceType(RaceType.menu);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
