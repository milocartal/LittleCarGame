﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownUIHandler : MonoBehaviour
{
    public TMP_Text countDownText;
    public int timeToWait = 3;

    private void Awake()
    {
        countDownText.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownCO());
    }

    IEnumerator CountDownCO()
    {
        yield return new WaitForSeconds(0.3f);

        int counter = timeToWait;

        while (true)
        {
            if (counter != 0)
                countDownText.text = counter.ToString();
            else
            {
                countDownText.text = "GO";

                GameManager.instance.OnRaceStart();

                break;
            }

            counter--;
            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }
}
