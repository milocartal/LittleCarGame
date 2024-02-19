using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnCars : MonoBehaviour
{
    [SerializeField]
    int RotationCar = 0;

    int numberOfCarsSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        

        //Ensure that the spawn points are sorted by name
        spawnPoints = spawnPoints.ToList().OrderBy(s => s.name).ToArray();

        //Load the car data
        CarData[] carDatas = Resources.LoadAll<CarData>("CarData/");
        CarData[] carDatasSpecial = Resources.LoadAll<CarData>("SpecialCarData/");

        //Driver info
        List<DriverInfo> driverInfoList = new List<DriverInfo>(GameManager.instance.GetDriverList());

        //Sort the drivers based on last position
        driverInfoList = driverInfoList.OrderBy(s => s.lastRacePosition).ToList();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Transform spawnPoint = spawnPoints[i].transform;

            if (driverInfoList.Count == 0)
                return;

            DriverInfo driverInfo = driverInfoList[0];

            int selectedCarID = driverInfo.carUniqueID;
            Debug.Log(spawnPoints.Length);

            if (GameManager.instance.GetRaceType() != RaceType.special)
            {
                //Find the selected car
                foreach (CarData cardata in carDatas)
                {
                    //We found the car data for the player
                    if (cardata.CarUniqueID == selectedCarID)
                    {
                        //Now spawn it on the spawnpoint
                        GameObject car = Instantiate(cardata.CarPrefab, spawnPoint.position, spawnPoint.rotation);

                        car.name = driverInfo.name;

                        car.transform.rotation = Quaternion.Euler(0, 0, RotationCar);
                        car.GetComponent<CarInputHandler>().playerNumber = driverInfo.playerNumber;

                        if (driverInfo.isAI)
                        {
                            car.GetComponent<CarInputHandler>().enabled = false;
                            car.GetComponent<TopDownCarController>().driftFactor = 0;
                            car.GetComponent<TopDownCarController>().turnFactor = 3.5f;
                            car.tag = "AI";
                        }
                        else
                        {
                            car.GetComponent<CarAIHandler>().enabled = false;
                            car.GetComponent<AStarLite>().enabled = false;
                            car.tag = "Player";
                        }

                        numberOfCarsSpawned++;

                        break;
                    }
                }
            }
            else
            {
                foreach (CarData cardata in carDatasSpecial)
                {
                    //We found the car data for the player
                    if (cardata.CarUniqueID == selectedCarID)
                    {
                        //Now spawn it on the spawnpoint
                        GameObject car = Instantiate(cardata.CarPrefab, spawnPoint.position, spawnPoint.rotation);

                        car.name = driverInfo.name;

                        car.transform.rotation = Quaternion.Euler(0, 0, RotationCar);
                        car.GetComponent<CarInputHandler>().playerNumber = driverInfo.playerNumber;

                        if (driverInfo.isAI)
                        {
                            car.GetComponent<CarInputHandler>().enabled = false;
                            car.GetComponent<TopDownCarController>().driftFactor = 0;
                            car.GetComponent<TopDownCarController>().turnFactor = 3.5f;
                            car.tag = "AI";
                        }
                        else
                        {
                            car.GetComponent<CarAIHandler>().enabled = false;
                            car.GetComponent<AStarLite>().enabled = false;
                            car.tag = "Player";
                        }

                        numberOfCarsSpawned++;

                        break;
                    }
                }
            }
            //Remove the spawned driver
            driverInfoList.Remove(driverInfo);
        }
    }

    public int GetNumberOfCarsSpawned()
    {
        return numberOfCarsSpawned;
    }

}
