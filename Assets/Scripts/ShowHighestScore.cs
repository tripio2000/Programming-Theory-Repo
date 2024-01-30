using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHighestScore : MonoBehaviour
{
    TextMeshProUGUI tmProHighScore;
    void Start()
    {
        tmProHighScore = GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey("highScore"))
        {
            tmProHighScore.text = $"Highest score: \n {PlayerPrefs.GetString("bestPlayerName")} {PlayerPrefs.GetInt("highScore")} at level {PlayerPrefs.GetInt("highestLevel")} ";
        }
        else
        {
            tmProHighScore.text = $"Highest score: 0";
        }
        
    }
}
