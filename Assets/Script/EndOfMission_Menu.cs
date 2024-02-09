using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfMission_Menu : MonoBehaviour
{

    public GameObject EndOfMissionUI;
    public GameObject pauseMenuUI;

    public void EndOfMission()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(false);
        EndOfMissionUI.SetActive(true);

    }

    
}
