using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public AudioMixerGroup mixerGroup;
    public string floatName;
    void Start()
    {
        Slider sliderComp = GetComponent<Slider>();
        float value;
        bool result = mixerGroup.audioMixer.GetFloat(floatName, out value);
        if (result)
            sliderComp.SetValueWithoutNotify(value);
    }

}
