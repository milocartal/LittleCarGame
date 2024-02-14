using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSetting : MonoBehaviour
{

    public void SetMasterVolume(float volume)
    {
        AudioManager.instance.SetMasterVolume(volume);
    }

    public void SetCarVolume(float volume)
    {
        AudioManager.instance.SetCarVolume(volume);
    }

    public void SetMusicVolume(float volume)
    {
        AudioManager.instance.SetMusicVolume(volume);
    }
}
