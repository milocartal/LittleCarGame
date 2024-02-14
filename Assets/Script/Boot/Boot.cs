using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{

    int RecupVariab;

    // Start is called before the first frame update
    void Start()
    {
        int RecupVariable = PlayerPrefs.GetInt("TutorialLaunched");

        //Debug.Log(RecupVariable);

        int ColorBlindfMode = PlayerPrefs.GetInt("ColorBlindMode");

        //Debug.Log(ColorBlindfMode);


        if (RecupVariable == 1)
        {
            LaunchCorrectScene("MainMenu");
        }
        else
        {
            LaunchCorrectScene("Tuto");
        }
    }

    // Update is called once per frame
    void LaunchCorrectScene(string NameOfTheScene)
    {
        SceneManager.LoadScene(NameOfTheScene);
    }
}
