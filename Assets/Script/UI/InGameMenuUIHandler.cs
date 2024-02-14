using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuUIHandler : MonoBehaviour
{
    //Other components
    public GameObject canvas;

    private void Awake()
    {
        canvas.SetActive(false);

        //Hook up events
        GameManager.instance.OnGameStateChanged += OnGameStateChanged;
    }
   
    public void OnNextRace()
    {
        switch(GameManager.instance.GetRaceType())
        {
            case RaceType.gp:
                Debug.Log("GP");
                break;

            case RaceType.simple:
                Debug.Log("simple");
                break;

            case RaceType.chrono:
                break;


            default:
                Debug.LogError("No correct race type");
                break;
        }
    }

    public void OnRaceAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    IEnumerator ShowMenuCO()
    {
        yield return new WaitForSeconds(1);

        canvas.SetActive(true);
    }

    //Events 
    void OnGameStateChanged(GameManager gameManager)
    {
        if (GameManager.instance.GetGameState() == GameStates.raceOver)
        {
            StartCoroutine(ShowMenuCO());
        }
    }

    void OnDestroy()
    {
        //Unhook events
        GameManager.instance.OnGameStateChanged -= OnGameStateChanged;
    }

}
