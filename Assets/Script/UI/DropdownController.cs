using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownController : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("ColorBlindMode"));
    }

}
