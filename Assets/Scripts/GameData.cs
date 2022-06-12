using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public string currentPlayerName;
    public int currentPlayerScore;

    public string bestPlayerName;
    public int bestPlayerScore;


    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestPlayerScore;

        public SaveData(string bestPlayerName, int bestPlayerScore)
        {
            this.bestPlayerScore = bestPlayerScore;
            this.bestPlayerName = bestPlayerName;
        }

    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        bestPlayerName = "No one yet";
        bestPlayerScore = 0;
        currentPlayerName = "Anonimo";
        loadBestData();
    }

    public void loadBestData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            bestPlayerScore = data.bestPlayerScore;
        }
    }

    public void SaveBestData()
    {
        SaveData data = new SaveData(bestPlayerName, bestPlayerScore);


        if (currentPlayerScore > bestPlayerScore)
        {
            data.bestPlayerName = currentPlayerName;
            data.bestPlayerScore = currentPlayerScore;
            bestPlayerName = currentPlayerName;
            bestPlayerScore = currentPlayerScore;
        }

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

}
