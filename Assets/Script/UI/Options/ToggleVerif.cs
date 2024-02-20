using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleVerif : MonoBehaviour
{
    Toggle driftToggle;
    // Start is called before the first frame update
    void Start()
    {
        driftToggle = GetComponent<Toggle>();
        if (PlayerPrefs.GetInt("EnabledDriftMode") == 0) driftToggle.isOn = false;
        else driftToggle.isOn = true;
    }
}
