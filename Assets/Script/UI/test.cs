using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{

    [Header("Car prefab")]
    public GameObject carPrefab;

    [Header("Spawn on")]
    public Transform spawnOnTransform;

    //Other components
    CarUIHandler carUIHandler = null;


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

        GameObject instantiatedCar = Instantiate(carPrefab, spawnOnTransform);

        carUIHandler = instantiatedCar.GetComponent<CarUIHandler>();

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

    //Permettra de definir que le bouton 1 aura la voiture avec l'ID 1
    public void OnSelectCar2(int selectedCarIndexPublic)
    {
        PlayerPrefs.SetInt("P1SelectedCarID", carDatas[selectedCarIndexPublic].CarUniqueID);
        PlayerPrefs.SetInt("P2SelectedCarID", carDatas[selectedCarIndex].CarUniqueID);


        PlayerPrefs.Save();

        //SceneManager.LoadScene("Circuit 01");
    }

}
