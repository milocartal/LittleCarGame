using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class test : MonoBehaviour
{

    [Header("Car prefab")]
    public GameObject carPrefab;

    [Header("Spawn on")]
    public Transform spawnOnTransform;

    public PlayMenuManager PlayMenuM;


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

    // Start is called before the first frame update
    void Start()
    {
        //PlayMenuManager PlayMenuM = null;

        //PlayMenuM = FindObjectOfType<PlayMenuManager>();

        carDatas = Resources.LoadAll<CarData>("CarData/");
        VectTempCar = spawnOnTransform.position;
        VectTempCar.x -= 180;
        VectTempCar.y += 143;
        //Load the car data
        //Instantiate(carPrefab);

        //On va crée des boutons
        for (int i = 0; i < carDatas.Length; i++)
        {
            int tempId = carDatas[i].carUniqueID;
            TempCar = Instantiate(carPrefab, VectTempCar, spawnOnTransform.rotation ,spawnOnTransform);
            carUIHandler = TempCar.GetComponent<CarUIHandler>();
            carUIHandler.SetupCar(carDatas[i]);
            VectTempCar.x += 200;
            
            Button tempBtn = TempCar.GetComponent<Button>();
            tempBtn.onClick.AddListener(() => { OnSelectCar(tempId); });
        }

    }



    public void OnSelectCar(int id)
    {
        GameManager.instance.ClearDriversList();

        GameManager.instance.AddDriverToList(1, "P1", carDatas[id].CarUniqueID, false);

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

        PlayMenuM.GetComponent<PlayMenuManager>().Go_To_Choix_Car_For_Course_Simple_Menu();

        //PlayerPrefs.SetInt("P1SelectedCarID", carDatas[id].carUniqueID);
        //PlayerPrefs.Save();

        //PlayerPrefs.Save();
    }

}
