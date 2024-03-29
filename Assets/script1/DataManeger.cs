using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class DataManeger : MonoBehaviour
{
    public static DataManeger Instance;
    public int hightScore;
    private void Awake()
    {
        if(Instance==null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance!=this)
        {
            Destroy(gameObject);
        }
    }
    public void SaveData()
    {
        BinaryFormatter Binform = new BinaryFormatter();//crate the binFormater
        FileStream file = File.Create(Application.persistentDataPath+"/gameInfo.dat");
        gameData data = new gameData();//creating the new contaner for game daata
        data.highscore = hightScore;
        Binform.Serialize(file, data);//serialized
        file.Close();//closes file

    }
    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open (Application.persistentDataPath + "/gameInfo.dat",FileMode.Open);
            gameData data = (gameData)BinForm.Deserialize(file);
            file.Close();
            hightScore = data.highscore;
           
        }
    }


}
[SerializeField]
class gameData
{
    public int highscore;
}
