using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfMission_Menu : MonoBehaviour
{
    public TMP_Text CounterTrashFinal;

    int RecupValue = 0;

    public GameObject EndOfMissionUI;
    public GameObject pauseMenuUI;

    public void EndOfMission()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(false);
        EndOfMissionUI.SetActive(true);

        //On r�cup�re le score final qui est sauvegard�
        RecupValue = PlayerPrefs.GetInt("TrashCounter");
        CounterTrashFinal.text = RecupValue.ToString();
    }

    
}
