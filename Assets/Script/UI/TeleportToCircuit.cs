using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToCircuit : MonoBehaviour
{
    public string DestinationCircuit;

    public void GoToCircuit_X()
    {
        SceneManager.LoadScene(DestinationCircuit);
    }
}
