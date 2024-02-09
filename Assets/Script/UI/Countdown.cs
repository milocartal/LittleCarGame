using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{

    public TMP_Text timeText;
    public float remainingTime;

    public EndOfMission_Menu EndOfM_MenuObject;

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;

            //Quand le timer arrive à zéro on affiche un canvas
            EndOfM_MenuObject.GetComponent<EndOfMission_Menu>().EndOfMission();
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timeText.text = $"{minutes.ToString("00")}:{seconds.ToString("00")}";
    }
}
