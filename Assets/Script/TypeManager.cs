using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeManager : MonoBehaviour
{
    public void SetSimple()
    {
        GameManager.instance.SetRaceType(RaceType.simple);
    }

    public void SetGP()
    {
        GameManager.instance.SetRaceType(RaceType.gp);
    }

    public void SetChrono()
    {
        GameManager.instance.SetRaceType(RaceType.chrono);
    }

    public void SetSpecial()
    {
        GameManager.instance.SetRaceType(RaceType.special);
    }

    public void SetMenu()
    {
        GameManager.instance.SetRaceType(RaceType.menu);
    }
}
