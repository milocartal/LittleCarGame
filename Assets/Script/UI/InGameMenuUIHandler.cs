using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuUIHandler : MonoBehaviour
{

    public GameObject GPEndMenu;
    public GameObject ChronoEndMenu;
    public GameObject MissionEndMenu;
    public GameObject SimpleEndMenu;

    private TeleportToCircuit teleportToCircuit;

    private void Awake()
    {
        GPEndMenu.SetActive(false);
        ChronoEndMenu.SetActive(false);
        MissionEndMenu.SetActive(false);
        SimpleEndMenu.SetActive(false);

        //Hook up events
        GameManager.instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void Start()
    {
        teleportToCircuit = FindObjectOfType<TeleportToCircuit>();
    }

    private void FixedUpdate()
    {
        if (!teleportToCircuit)
        {
            teleportToCircuit = FindObjectOfType<TeleportToCircuit>();
        }
    }

    public void OnNextRace()
    {
        if (GameManager.instance.GetNumberOfRace() == GameManager.instance.GetMaxNumberOfRace() && GameManager.instance.GetRaceType() == RaceType.gp)
        {
            teleportToCircuit.GoToCircuit_X("MainMenu");
        }
        else
        {
            switch (GameManager.instance.GetRaceType())
            {
                case RaceType.gp:
                    teleportToCircuit.LoadingCircuitRandom();
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

        switch (GameManager.instance.GetRaceType())
        {
            case RaceType.gp:
                GPEndMenu.SetActive(true);
                break;
            case RaceType.simple:
                SimpleEndMenu.SetActive(true);
                break;
            case RaceType.chrono:
                ChronoEndMenu.SetActive(true);
                break;
            case RaceType.special:
                MissionEndMenu.SetActive(true);
                break;
            default:
                Debug.Log("default");
                SimpleEndMenu.SetActive(true);
                break;
        }
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
