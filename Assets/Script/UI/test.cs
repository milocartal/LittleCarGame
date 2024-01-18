using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{


    //Array de carDatas
    CarData[] carDatas;

    //Index de la voiture
    int selectedCarIndex = 0;
    public int selectedCarIndexPublic = 1;

    //Other components

    // Start is called before the first frame update
    void Start()
    {
        //Load the car data
        carDatas = Resources.LoadAll<CarData>("CarData/");

    }



    public void OnSelectCar()
    {
        GameManager.instance.ClearDriversList();

        GameManager.instance.AddDriverToList(1, "P1", carDatas[selectedCarIndex].CarUniqueID, false);

        //Create a new list of cars
        List<CarData> uniqueCars = new List<CarData>(carDatas);

        //Remove the car that player has selected
        uniqueCars.Remove(carDatas[selectedCarIndex]);

        string[] names = { "Freddy", "Eddy", "Teddy", "Buddy", "Luddy", "Puddy" };
        List<string> uniqueNames = names.ToList<string>();

        //Add AI drivers
        for (int i = 2; i < 5; i++)
        {
            string driverName = uniqueNames[Random.Range(0, uniqueNames.Count)];
            uniqueNames.Remove(driverName);

            CarData carData = uniqueCars[Random.Range(0, uniqueCars.Count)];

            GameManager.instance.AddDriverToList(i, driverName, carData.CarUniqueID, true);

        }

        SceneManager.LoadScene("Circuit 01");
    }

    public void OnSelectCar2()
    {
        PlayerPrefs.SetInt("P1SelectedCarID", carDatas[selectedCarIndexPublic].CarUniqueID);
        PlayerPrefs.SetInt("P2SelectedCarID", carDatas[selectedCarIndex].CarUniqueID);


        PlayerPrefs.Save();

        SceneManager.LoadScene("Circuit 01");
    }

}
