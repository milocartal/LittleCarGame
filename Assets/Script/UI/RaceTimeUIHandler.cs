using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaceTimeUIHandler : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text EndTimeText;

    [Header("Durée des missions en seconde")]
    public float remainingTime;

    float lastRaceTimeUpdate = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.GetRaceType() != RaceType.special)
        {
            StartCoroutine(UpdateTimeCO());
        }
        else
        {
            StartCoroutine(UpdateTimeCountDown());
        }
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
                EndTimeText.text = $"{raceTimeMinutes.ToString("00")}:{raceTimeSeconds.ToString("00")}";

                lastRaceTimeUpdate = raceTime;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator UpdateTimeCountDown()
    {
        while (true)
        {
            if (GameManager.instance.GetGameState() == GameStates.running)
            {
                if (remainingTime > 0)
                {
                    remainingTime -= 1;
                }

                else
                {
                    FindObjectOfType<Count_Trash>().Save_Trash_Count();
                    GameManager.instance.OnRaceCompleted();
                }

                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                timeText.text = $"{minutes.ToString("00")}:{seconds.ToString("00")}";

                
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
