using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrash : MonoBehaviour
{
    public GameObject TrashPrefab;
    public int maxNumberOfTrash = 50;
    public int max_y = 100;
    public int max_x = 100;

    void Start()
    {
        //Au début on en fait spawner un certain nombre
        SpawnTrash(maxNumberOfTrash);
    }
    
    
    void Update()
    {
        int numberOftrashInScene = FindObjectsOfType<TrashPickUp>().Length;
        if (numberOftrashInScene < maxNumberOfTrash - 1 ) 
        {
            SpawnTrash(1);
        }
    }

    //Script utilisé dans Count_Trash
    public void SpawnTrash (int numberofTrash)
    {
        for (int i = 0; i <= numberofTrash; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-max_x, max_x), Random.Range(-max_y, max_y));
            Instantiate(TrashPrefab, pos, Quaternion.identity);
        }
    }
}
