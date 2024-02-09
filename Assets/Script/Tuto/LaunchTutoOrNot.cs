using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchTutoOrNot : MonoBehaviour
{

    int RecupVariab;

    // Start is called before the first frame update
    void Start()
    {
        int RecupVariable = PlayerPrefs.GetInt("TutorialLaunched");

        Debug.Log(RecupVariable);



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
