using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    string currentSceneName;
    //Récupérer la scène 

    void Start ()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

    }


    // Update is called once per frame
    void Update()
    {
        //Si on appuie sur Echap
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }

    //Si on est en pause
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        //timeScale zéro : time freeze
        Time.timeScale = 0f;
        GameIsPaused = true;
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
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
