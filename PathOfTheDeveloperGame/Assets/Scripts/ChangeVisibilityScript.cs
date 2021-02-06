using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeVisibilityScript : MonoBehaviour
{
    //This script changes visibility of the object such that it can be adapted during runtime and is automatically invisbile when newly loaded.
    public void Awake()
    {
        gameObject.SetActive(false);
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
        gameObject.SetActive(false);
    }

    public void makeSelfInvisible()
    {
        gameObject.SetActive(false);
    }

    public void makeSelfVisible()
    {
        gameObject.SetActive(true);
    }
}
