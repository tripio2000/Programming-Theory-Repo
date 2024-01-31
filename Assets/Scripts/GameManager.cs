using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance { get; private set; }
    public UnityAction OnLevelFinish;

    float horizontalInput,verticalInput;
    [SerializeField] int currentLevel = 1;
    [SerializeField] public int ballsLeft = 10;
    float difficultyMultiplier=1.2f;
    SpawnSphere spawnSphere;
    Counter counter;
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
    public void Restart()
    {
        currentLevel = 1;
        ballsLeft = 10;
        PersistentDataManager.instance.currentScore = 0;
    }
    void IncreaseDifficulty()
    {
        if (PersistentDataManager.instance.currentScore < 0) { PlayerPrefs.SetInt("highestLevel",currentLevel); FinishGame(); } //Finish game
        //Increase level
        currentLevel++;
        //Increase ball count
        spawnSphere.numberOfSpheres = (int)(difficultyMultiplier* spawnSphere.numberOfSpheres);
        Debug.Log($"New amount of balls {spawnSphere.numberOfSpheres}");
        //Increase gravity
        Physics.gravity *= difficultyMultiplier;
        //Reset counter;
        counter.count = 0;
        spawnSphere.LaunchNextWave();
    }
    public void ChangeBallCount()
    {
        if (counter == null) { counter = FindObjectOfType<Counter>(); }
        if (spawnSphere == null) { spawnSphere = FindObjectOfType<SpawnSphere>(); }
        ballsLeft = spawnSphere.numberOfSpheres - counter.count;
        if (ballsLeft == 0)
        {
            Debug.Log("Finished level!");
            IncreaseDifficulty();
            //OnLevelFinish.Invoke();
        }
    }
    public void FinishGame()
    {
        FindObjectOfType<SceneManager>().ChangeScene();
    }
    public void Exit()
    {
        Application.Quit();
    }
}