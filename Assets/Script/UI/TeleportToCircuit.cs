using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToCircuit : MonoBehaviour
{

    int NumberOfRace;
    //int randomNumber;
    string RandomNumber;

    public void Start()
    {
        int NumberOfRace = SceneManager.sceneCountInBuildSettings;
        //int randomNumber = Random.Range(1, 8);


    }

    public void GoToCircuit_X(string DestinationCircuit)
    {
        SceneManager.LoadScene(DestinationCircuit);
    }

    

    //POUR LE GP
    //Va générer un nombre aléatoire
    public void LoadingCircuitRandom()
    {
        //string TargetGRNFR = GenerateRandomNumberForRace();
        //Si le nombre aléatoire tire vers un circuit qui n'existe pas

        //SceneManager.LoadScene(3);
        Debug.Log(RandomNumber = GenerateRandomNumberForRace());
        //GenerateRandomNumberForRace();
        SceneManager.LoadScene(RandomNumber);
    }

    
    public string GenerateRandomNumberForRace()
    {
        int randomNumber = Random.Range(1, 8);
        string TargetRace = "Circuit 0" + randomNumber;
        return TargetRace;
    }
    

}
