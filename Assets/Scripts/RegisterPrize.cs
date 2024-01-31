using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegisterPrize : MonoBehaviour
{
    public int score;
    [SerializeField] TextMeshProUGUI tmProScore;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            //Register player score
            PersistentDataManager.instance.UpdateScore(score);
            tmProScore.text = $"Current score: {PersistentDataManager.instance.currentScore}";
        }
    }
}
