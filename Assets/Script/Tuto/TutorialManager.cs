using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public GameObject[] popUps;
    private int popUpIndex;
    private bool isJumped = false;
    private bool isZoneFreinage = false;
    private bool isZoneTerre = false;
    private bool isEnd = false;

    //Pour savoir si le jeu vous téléporte dans la scène du tuto ou non

    void Start()
    {
        GameManager.instance.SetRaceType(RaceType.tuto);

        PlayerPrefs.SetInt("TutorialLaunched", 1);
    }

    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            } else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
            if (isZoneFreinage)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            if (isJumped)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 6)
        {
            if (isZoneTerre)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 7)
        {
            if (isEnd)
            {
                popUpIndex++;
            }
        }
    }

    public void setIsJumped(bool state)
    {
        isJumped = state;
    }
    public void setIsZoneFreinage(bool state)
    {
        isZoneFreinage = state;
    }
    public void setIsZoneTerre(bool state)
    {
        isZoneTerre = state;
    }
    public void setIsEnd(bool state)
    {
        isEnd = state;
    }
}
