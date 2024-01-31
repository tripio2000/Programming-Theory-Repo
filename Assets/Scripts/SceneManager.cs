using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneManager : MonoBehaviour
{
    int buildIndex;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        buildIndex = 0;
    }
    public void ChangeScene()
    {
        if(buildIndex == UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("Launching menu");
            buildIndex=0; //Last scene, return to menu
        }
        else
        {
            Debug.Log("Launching game");
            buildIndex++; //Load next scene
        }
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(buildIndex);
    }
}
