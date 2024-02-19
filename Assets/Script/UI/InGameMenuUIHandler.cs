using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InGameMenuUIHandler : MonoBehaviour
{

    public GameObject GPEndMenu;
    public GameObject ChronoEndMenu;
    public GameObject MissionEndMenu;
    public GameObject SimpleEndMenu;

    [SerializeField] private GameObject _gp;
    [SerializeField] private GameObject _simple;
    [SerializeField] private GameObject _chrono;
    [SerializeField] private GameObject _special;

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
        switch(GameManager.instance.GetRaceType())
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
                EventSystem.current.SetSelectedGameObject(_gp);
                break;
            case RaceType.simple:
                SimpleEndMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(_simple);
                break;
            case RaceType.chrono:
                ChronoEndMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(_chrono);
                break;
            case RaceType.special:
                MissionEndMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(_special);
                break;
            default:
                Debug.Log("default");
                SimpleEndMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(_simple);
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
