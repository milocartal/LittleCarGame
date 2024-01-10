using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SaveChrono (GameManager gameManager)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/chrono.chrono";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        ChronoData chronoData = new ChronoData(gameManager);
        binaryFormatter.Serialize(fileStream, chronoData);
        fileStream.Close();
    }
}
