using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Count_Trash : MonoBehaviour
{
    public TMP_Text CountTrash;
    public TMP_Text EndScore;

    int NumberOfTrashColleted = 0;

    public void AddTrash(int i)
    {
        NumberOfTrashColleted += i;
        CountTrash.text = NumberOfTrashColleted.ToString();
        EndScore.text = $"Poubelles ramassées : {NumberOfTrashColleted.ToString("00")}";
    }

    public void Save_Trash_Count ()
    {
        PlayerPrefs.SetInt("TrashCounter", NumberOfTrashColleted);
    }
}
