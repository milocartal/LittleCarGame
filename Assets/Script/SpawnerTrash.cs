using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrash : MonoBehaviour
{
    public GameObject TrashPrefab;
    public int Start_NumberOfTrash = 50;

    void Start()
    {
        //Au début on en fait spawner un certain nombre
        SpawnTrash(Start_NumberOfTrash);
    }
    
    
    void Update()
    {
        int numberOftrashInScene = GameObject.FindObjectsOfType<TrashPickUp>().Length;
        if (numberOftrashInScene < Start_NumberOfTrash - 1 ) 
        {
            SpawnTrash(1);
        }
    }

    //Script utilisé dans Count_Trash
    public void SpawnTrash (int numberofTrash)
    {
        for (int i = 0; i <= numberofTrash; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
            Instantiate(TrashPrefab, pos, Quaternion.identity);
        }
    }
}
