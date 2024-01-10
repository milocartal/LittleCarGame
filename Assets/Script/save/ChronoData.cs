using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChronoData
{
    public string chrono;

    public ChronoData (GameManager gameManager)
    {
        chrono = gameManager.GetRaceTime().ToString();
    }
}
