using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar2 : MonoBehaviour
{
    void Start()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        //Load car Data
        CarData[] carDatas = Resources.LoadAll<CarData>("CarData/");

        //-------------------AJOUT-------------------------

        //Driver info
        List<DriverInfo> driverInfoList = new List<DriverInfo>(GameManager.instance.GetDriverList());

        //Sort the drivers based on last position
        //
        //driverInfoList = driverInfoList.OrderBy(s => s.lastRacePosition).ToList();

        //-----------------------------------------------

        for (int i  = 0; i < spawnPoints.Length; i++)
        {
            Transform spawnPoint = spawnPoints[i].transform;

            //------------------------------------------AJOUT
            DriverInfo driverInfo = driverInfoList[0];

            int selectedCarID = driverInfo.carUniqueID;

            //------------------------------------------------

            int playerSelectedCarID = PlayerPrefs.GetInt($"P{i +1}SelectedCarID");

            //Find the player car Prefab
            foreach (CarData cardata in carDatas)
            {
                if (cardata.CarUniqueID == playerSelectedCarID)
                {
                    //Now spawn in spawnpoint
                    GameObject car = Instantiate(cardata.CarPrefab, spawnPoint.position, spawnPoint.rotation);

                    //-------AJOUT------------
                    car.name = driverInfo.name;
                    //----------------------

                    //OLD
                    //car.GetComponent<CarInputHandler>().playerNumber = i + 1;

                    //NEW
                    car.GetComponent<CarInputHandler>().playerNumber = driverInfo.playerNumber;

                    //----------------------AJOUT------------------------
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
                    //-------------------------------------------------------

                    break;
                }
            }
        }
    }
}
