﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaceTimeUIHandler : MonoBehaviour
{
    public TMP_Text timeText;

    float lastRaceTimeUpdate = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateTimeCO());
    }

    IEnumerator UpdateTimeCO()
    {
        while (true)
        {
            float raceTime = GameManager.instance.GetRaceTime();

            if (lastRaceTimeUpdate != raceTime)
            {
                int raceTimeMinutes = (int)Mathf.Floor(raceTime / 60);
                int raceTimeSeconds = (int)Mathf.Floor(raceTime % 60);

                timeText.text = $"{raceTimeMinutes.ToString("00")}:{raceTimeSeconds.ToString("00")}";

                lastRaceTimeUpdate = raceTime;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
