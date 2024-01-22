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

        //Driver info
        List<DriverInfo> driverInfoList = new List<DriverInfo>(GameManager.instance.GetDriverList());

        

        for (int i  = 0; i < spawnPoints.Length; i++)
        {
            Transform spawnPoint = spawnPoints[i].transform;

            int playerSelectedCarID = PlayerPrefs.GetInt($"P{i +1}SelectedCarID");

            //Find the player car Prefab
            foreach (CarData cardata in carDatas)
            {
                if (cardata.CarUniqueID == playerSelectedCarID)
                {
                    //Now spawn in spawnpoint
                    GameObject playerCar = Instantiate(cardata.CarPrefab, spawnPoint.position, spawnPoint.rotation);

                    playerCar.GetComponent<CarInputHandler>().playerNumber = i + 1;

                    break;
                }
            }
        }
    }
}
