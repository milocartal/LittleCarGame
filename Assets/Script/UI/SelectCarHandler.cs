using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCarHandler : MonoBehaviour
{

    [Header("Car prefab")]
    public GameObject carPrefab;

    [Header("Spawn on")]
    public Transform spawnOnTransform;
    public Transform spawnOnTransformSpecial;

    public PlayMenuManager PlayMenuM;
    public TeleportToCircuit TeleportToCObject;


    CarUIHandler carUIHandler = null;

    CarData[] carDatas;
    CarData[] specialCarDatas;

    int selectedCarIndex = 1;

    private GameObject TempCar;

    private GameObject _voiture1;
    private GameObject _specialCar;

    // Start is called before the first frame update
    void Start()
    {
        carDatas = Resources.LoadAll<CarData>("CarData/");
        specialCarDatas = Resources.LoadAll<CarData>("SpecialCarData/");


        //On va crée des boutons
        for (int i = 0; i < carDatas.Length; i++)
        {
            int tempId = carDatas[i].carUniqueID;
            TempCar = Instantiate(carPrefab, spawnOnTransform.position, spawnOnTransform.rotation ,spawnOnTransform);
            carUIHandler = TempCar.GetComponent<CarUIHandler>();
            carUIHandler.SetupCar(carDatas[i]);
            
            Button tempBtn = TempCar.GetComponent<Button>();
            tempBtn.onClick.AddListener(() => { OnSelectCar(tempId); });

            if (i == 0)
            {
                _voiture1 = TempCar;
            }
        }

        for (int i = 0; i < specialCarDatas.Length; i++)
        {
            int tempId = specialCarDatas[i].carUniqueID - 50;
            TempCar = Instantiate(carPrefab, spawnOnTransformSpecial.position, spawnOnTransformSpecial.rotation, spawnOnTransformSpecial);
            carUIHandler = TempCar.GetComponent<CarUIHandler>();
            carUIHandler.SetupCar(specialCarDatas[i]);

            Button tempBtn = TempCar.GetComponent<Button>();
            tempBtn.onClick.AddListener(() => { OnSelectCar(tempId); });

            if (i == 0)
            {
                _specialCar = TempCar;
            }
        }
    }

    public GameObject getBouttonVoiture()
    {
        return _voiture1;
    }

    public GameObject getBouttonVoitureSpeciale()
    {
        return _specialCar;
    }

    public void OnSelectCar(int id)
    {
        GameManager.instance.ClearDriversList();
        Debug.Log(id);

        if (GameManager.instance.GetRaceType() != RaceType.special)
        {
            GameManager.instance.AddDriverToList(1, "P1", carDatas[id].CarUniqueID, false);
        } else
        {
            GameManager.instance.AddDriverToList(1, "P1", specialCarDatas[id].CarUniqueID, false);
        }

        //Create a new list of cars
        List<CarData> uniqueCars = new List<CarData>(carDatas);

        //Remove the car that player has selected
        uniqueCars.Remove(carDatas[selectedCarIndex]);

        string[] names = { "Freddy", "Eddy", "Teddy", "Buddy", "Luddy", "Puddy" };
        List<string> uniqueNames = names.ToList<string>();

        //Add AI drivers
        if (GameManager.instance.GetRaceType() != RaceType.chrono && GameManager.instance.GetRaceType() != RaceType.special)
        {
            for (int i = 2; i < 5; i++)
            {
                string driverName = uniqueNames[Random.Range(0, uniqueNames.Count)];
                uniqueNames.Remove(driverName);

                CarData carData = uniqueCars[Random.Range(0, uniqueCars.Count)];

                GameManager.instance.AddDriverToList(i, driverName, carData.CarUniqueID, true);

            }
        }

        switch(GameManager.instance.GetRaceType())
        {
            case (RaceType.simple):
            case (RaceType.chrono):
                PlayMenuM.GetComponent<PlayMenuManager>().GoToTrackMenu();
                break;
            case (RaceType.gp):
                TeleportToCObject.GetComponent<TeleportToCircuit>().LoadingCircuitRandom();
                break;
            case (RaceType.special):
                TeleportToCObject.GetComponent<TeleportToCircuit>().GoToCircuit_X("Mode_SP_01");
                break;
        }

        //PlayerPrefs.SetInt("P1SelectedCarID", carDatas[id].carUniqueID);
        //PlayerPrefs.Save();

        //PlayerPrefs.Save();
    }

}
