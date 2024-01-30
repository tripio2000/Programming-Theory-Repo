using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance { get; private set; }
    [SerializeField] public string playerName;
    [SerializeField] public int currentScore;
    [SerializeField] public int highestScore;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself, else instance myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public void UpdateScore(int scoreChange)
    {
        currentScore += scoreChange;
        if (currentScore > highestScore) 
        { 
            highestScore = currentScore; 
            PlayerPrefs.SetInt("highScore", highestScore);
            PlayerPrefs.SetString("bestPlayerName",PlayerData.instance.playerName);
        } //Update highest score
        
    }
    public void SetPlayerName(string name)
    {
        playerName = name;
    }
}

