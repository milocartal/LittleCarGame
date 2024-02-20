using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("EnabledDriftMode", 1);

        StartCoroutine(StartGame());
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            LaunchCorrectScene();
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(5);

        LaunchCorrectScene();
    }

    void LaunchCorrectScene()
    {
        int RecupVariable = PlayerPrefs.GetInt("TutorialLaunched");

        if (RecupVariable == 1)
        {
            GameManager.instance.SetRaceType(RaceType.menu);
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            GameManager.instance.SetRaceType(RaceType.tuto);
            SceneManager.LoadScene("Tuto");
        }
    }
}
