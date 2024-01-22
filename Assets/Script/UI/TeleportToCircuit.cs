using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToCircuit : MonoBehaviour
{

    public void GoToCircuit_X(string DestinationCircuit)
    {
        SceneManager.LoadScene(DestinationCircuit);
    }
}
