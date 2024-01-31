using System;
using System.IO;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    //public static PlayerData instance { get; private set; }
    //[SerializeField] public string playerName;
    //[SerializeField] public int currentScore;
    //[SerializeField] public int highestScore;
    public string currentPlayerName, bestPlayerName;
    public int currentScore, highestScore;

    #region SINGLETON
    public static PersistentDataManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerData();
    }
    #endregion

    public void UpdateScore(int scoreChange)
    {
        currentScore += scoreChange;
        if (currentScore > highestScore)//Update highest score
        {
            highestScore = currentScore;
            bestPlayerName = currentPlayerName;
        } 
    }
    public void SetPlayerName(string newName)
    {
        currentPlayerName = newName;
    }
    #region DATA PERSISTENCE
    [Serializable]
    class PlayerData
    {
        public string currentPlayerName, bestPlayerName;
        public int highestScore;
    }
    public void SavePlayerData()
    {
        PlayerData data = new PlayerData();
        data.bestPlayerName = bestPlayerName;
        data.highestScore = highestScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            bestPlayerName = data.bestPlayerName;
            highestScore = data.highestScore;
        }
    }
    #endregion
}

