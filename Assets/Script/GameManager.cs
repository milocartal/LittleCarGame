using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using Unity.VisualScripting;

public enum GameStates { countDown, running, raceOver };

public enum RaceType { simple, gp, chrono, special, menu, tuto };

public class GameManager : MonoBehaviour
{
    //Static instance of GameManager so other scripts can access it
    public static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            // Si l'instance n'existe pas, essayez de la trouver dans la scène
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                // Si elle n'existe toujours pas, créez un nouvel objet GameManager
                if (instance == null)
                {
                    GameObject gameManagerObject = new GameObject("GameManager");
                    instance = gameManagerObject.AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }

    //Mode Grand Prix
    private List<string> Circuits = new List<string>(8);
    private int numberOfRace = 0;
    private int maxNumberOfRace = 4;

    //States
    GameStates gameState = GameStates.countDown;
    RaceType raceType = RaceType.menu;

    //Time
    float raceStartedTime = 0;
    float raceCompletedTime = 0;

    //Driver information
    List<DriverInfo> driverInfoList = new List<DriverInfo>();

    //Events
    public event Action<GameManager> OnGameStateChanged;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Supply dummy driver information for testing purposes
        driverInfoList.Add(new DriverInfo(1, "P1", 0, false));

        Circuits.Add("Circuit 01");
        Circuits.Add("Circuit 02");
        Circuits.Add("Circuit 03");
        Circuits.Add("Circuit 04");
        Circuits.Add("Circuit 05");
        Circuits.Add("Circuit 06");
        Circuits.Add("Circuit 07");
        Circuits.Add("Circuit 08");
    }

    void LevelStart()
    {
        gameState = GameStates.countDown;

        Debug.Log("Level started");
    }


    public GameStates GetGameState()
    {
        return gameState;
    }

    void ChangeGameState(GameStates newGameState)
    {
        if (gameState != newGameState)
        {
            gameState = newGameState;

            //Invoke game state change event
            OnGameStateChanged?.Invoke(this);
        }
    }

    public float GetRaceTime()
    {
        if (gameState == GameStates.countDown)
            return 0;
        else if (gameState == GameStates.raceOver)
            return raceCompletedTime - raceStartedTime;
        else return Time.time - raceStartedTime;
    }

    //Driver information handling
    public void ClearDriversList()
    {
        driverInfoList.Clear();
    }


    public void AddDriverToList(int playerNumber, string name, int carUniqueID, bool isAI)
    {
        driverInfoList.Add(new DriverInfo(playerNumber, name, carUniqueID, isAI));
    }

    public void SetDriversLastRacePosition(int playerNumber, int position)
    {
        DriverInfo driverInfo = FindDriverInfo(playerNumber);
        driverInfo.lastRacePosition = position;
    }

    public void AddPointsToChampionship(int playerNumber, int points)
    {
        DriverInfo driverInfo = FindDriverInfo(playerNumber);

        driverInfo.championshipPoints += points;
    }

    DriverInfo FindDriverInfo(int playerNumber)
    {
        foreach (DriverInfo driverInfo in driverInfoList)
        {
            if (playerNumber == driverInfo.playerNumber)
                return driverInfo;
        }

        Debug.LogError($"FindDriverInfoBasedOnDriverNumber failed to find driver for player number {playerNumber}");

        return null;
    }

    public List<DriverInfo> GetDriverList()
    {
        return driverInfoList;
    }

    public void OnRaceStart()
    {
        Debug.Log("OnRaceStart");

        raceStartedTime = Time.time;

        ChangeGameState(GameStates.running);
    }
    public void OnRaceCompleted()
    {
        Debug.Log("OnRaceCompleted");

        raceCompletedTime = Time.time;

        ChangeGameState(GameStates.raceOver);

        if(raceType == RaceType.gp)
        {
            numberOfRace += 1;
        }
        if(numberOfRace == maxNumberOfRace)
        {
            Debug.Log("Grand Prix Fini");
        }
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LevelStart();
    }


    public void SetRaceType(RaceType newRaceType)
    {
        raceType = newRaceType;
    }

    public RaceType GetRaceType()
    {
        return raceType;
    }

    public void SetDefaultCircuit(string[] circuitList)
    {
        Circuits.Clear();
        Circuits.Add("Circuit 01");
        Circuits.Add("Circuit 02");
        Circuits.Add("Circuit 03");
        Circuits.Add("Circuit 04");
        Circuits.Add("Circuit 05");
        Circuits.Add("Circuit 06");
        Circuits.Add("Circuit 07");
        Circuits.Add("Circuit 08");
    }

    public void RemoveCircuit(string circuit)
    {
        Circuits.Remove(circuit);
    }

    public List<string> GetCircuitList()
    {
        return Circuits;
    }

    public int GetNumberOfRace()
    {
        return numberOfRace;
    }
    public int GetMaxNumberOfRace()
    {
        return maxNumberOfRace;
    }

    public void AddRaceFinish(int number)
    {
        numberOfRace += number;
    }

    public void ResetNumberOfRace()
    {
        numberOfRace = 0;
    }
}
