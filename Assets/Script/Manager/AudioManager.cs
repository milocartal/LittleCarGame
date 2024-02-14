using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup master;
    public AudioMixerGroup cars;
    public AudioMixerGroup music;

    //Static instance of AudioManager so other scripts can access it
    public static AudioManager instance = null;

    public static AudioManager Instance
    {
        get
        {
            // Si l'instance n'existe pas, essayez de la trouver dans la scène
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();

                // Si elle n'existe toujours pas, créez un nouvel objet AudioManager
                if (instance == null)
                {
                    GameObject audioManagerObject = new GameObject("AudioManager");
                    instance = audioManagerObject.AddComponent<AudioManager>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetMasterVolume(float volume)
    {
        master.audioMixer.SetFloat("Master", volume);
    }

    public void SetCarVolume(float volume)
    {
        cars.audioMixer.SetFloat("Car", volume);
    }

    public void SetMusicVolume(float volume)
    {
        music.audioMixer.SetFloat("Music", volume);
    }
}
