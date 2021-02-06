using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameActiveText : MonoBehaviour
{
    [SerializeField] private Text text;

    public void Start()
    {
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += onLoadNewScene;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= onLoadNewScene;
    }

    private void onLoadNewScene(Scene scene, LoadSceneMode mode)
    {

    }

    public void changeGameState(bool state)
    {
        if (state)
        {
            text.text = "Game is running.";
        }
        else
        {
            text.text = "Build the course.";
        }
    }
}

