using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{

    public TMP_Text timeText;
    public float remainingTime;
    public Count_Trash CTObject;

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;

            //Qaund le timer arrrive à zéro on récupère le score final
            CTObject.GetComponent<Count_Trash>().Save_Trash_Count();
            //Quand on aura save le score on peut l'envoyer

        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timeText.text = $"{minutes.ToString("00")}:{seconds.ToString("00")}";
    }
}
