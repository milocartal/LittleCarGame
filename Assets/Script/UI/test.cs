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
    int selectedCarIndex = 1;
    //public int selectedCarIndexPublic = 1;

    //Pour la boucle de création
    private GameObject TempCar;
    private Vector3 VectTempCar;
    private int indexCarSelected_Pour_Boucle = 0;

    

    // Start is called before the first frame update
    void Start()
    {

        VectTempCar = spawnOnTransform.position;
        VectTempCar.x -= 180;
        VectTempCar.y += 143;
        //Load the car data
        carDatas = Resources.LoadAll<CarData>("CarData/");

        Instantiate(carPrefab);

        //GameObject instantiatedCar = Instantiate(carPrefab, spawnOnTransform);

        //carUIHandler = instantiatedCar.GetComponent<CarUIHandler>();

        //On va crée des boutons
        for (int i = 1; i < carDatas.Length; i++)
        {
            TempCar = Instantiate(carPrefab, VectTempCar, spawnOnTransform.rotation ,spawnOnTransform);
            carUIHandler = TempCar.GetComponent<CarUIHandler>();
            carUIHandler.SetupCar(carDatas[i]);
            //VectTempCar.x += 100;
            indexCarSelected_Pour_Boucle += 1;
            OnSelectCar2();
        }

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
    public void OnSelectCar2()
    {
        PlayerPrefs.SetInt("P1SelectedCarID", carDatas[indexCarSelected_Pour_Boucle].CarUniqueID);
        PlayerPrefs.SetInt("P2SelectedCarID", carDatas[indexCarSelected_Pour_Boucle].CarUniqueID);


        PlayerPrefs.Save();

        //SceneManager.LoadScene("Circuit 01");
    }

}
