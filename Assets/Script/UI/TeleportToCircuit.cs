using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToCircuit : MonoBehaviour
{
    List<string> Circuits;

    public void Start()
    {
        int NumberOfRace = SceneManager.sceneCountInBuildSettings;
        Circuits = GameManager.Instance.GetCircuitList();
    }

    public void GoToCircuit_X(string DestinationCircuit)
    {
        SceneManager.LoadScene(DestinationCircuit);
    }

    //Prend un circuit aléatoire dans la liste des Circuits et revoie dessus
    public void LoadingCircuitRandom()
    {
        int randomNumber = Random.Range(0, 7);
        string selectCircuit = Circuits[randomNumber];
        GameManager.instance.RemoveCircuit(selectCircuit);
        SceneManager.LoadScene(selectCircuit);
    }

}
