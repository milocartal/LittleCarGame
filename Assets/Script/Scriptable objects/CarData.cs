using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Car Data", menuName = "Car Data", order = 51)]
public class CarData : ScriptableObject
{
    [SerializeField]
    private int carUniqueID = 0;

    [SerializeField]
    private float carName;

    [SerializeField]
    private Sprite carUISprite;

    [SerializeField]
    private GameObject carPrefab;

    public int CarUniqueID
    {
        get { return carUniqueID; }
    }
    public float CarName
    {
        get { return carName; }
    }

    public Sprite CarUISprite
    {
        get { return carUISprite; }
    }
    public GameObject CarPrefab
    {
        get { return carPrefab; }
    }

}
