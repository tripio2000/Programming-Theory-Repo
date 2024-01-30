using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneManager : MonoBehaviour
{
    enum Scene {Start, Game, Results}
    Scene currentScene;
    int buildIndex;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        currentScene = Scene.Start;
        buildIndex = 0;
    }
    public void ChangeScene()
    {
        if(buildIndex == UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - 1)
        {
            buildIndex=0;
        }
        else
        {
            buildIndex++;
        }
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(buildIndex);
    }
}
