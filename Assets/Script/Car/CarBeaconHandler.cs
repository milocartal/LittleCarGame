using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarBeaconHandler : MonoBehaviour
{

    public GameObject RightBeacon;
    public GameObject LeftBeacon;
    private bool active = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            ChangeBeaconState();
        }
    }

    public void ChangeBeaconState()
    {
        active = !active;
        if(active)
        {
            StartCoroutine(ActiveBeacon());
        }
        else
        {
            RightBeacon.SetActive(false); LeftBeacon.SetActive(false);
        }
    }

    private IEnumerator ActiveBeacon()
    {
        while (active)
        {
            RightBeacon.SetActive(false);
            LeftBeacon.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            RightBeacon.SetActive(true);
            LeftBeacon.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
