using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NameManager : MonoBehaviour
{
    public static NameManager Instance;
    public string userName;
    public string championName;
    public int highestScore;

    [System.Serializable]
    class SaveData
    {
        public string championName;
        public int highestScore;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.championName = championName;
        data.highestScore = highestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        highestScore = 0;
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            championName = data.championName;
            highestScore = data.highestScore;
        }
    }

    private void Awake()
    {
        LoadInfo();
        if (Instance != null)
        {
            Debug.Log(userName);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
